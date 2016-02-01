using HtmlAgilityPack;
using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static UserProfile ParseProfile(string htmlData, ProfileParseConfig config)
		{
			var doc = new HtmlDocument();
			doc.Load(new StringReader(htmlData));

			var xpathConfig = config;
			var content = xpathConfig.ContentRootGetter(new[] { doc.DocumentNode }).Single();
			var infoMessage = xpathConfig.InfoMessageGetter(new[] { content }).SingleOrDefault();
			if (infoMessage != null) throw new SplatoonClientException(infoMessage.InnerText);

			var equipDetail = xpathConfig.EquipDetailGetter(new[] { content }).Single();

			var user = new UserProfile();
			{
				var userMain = xpathConfig.UserMainGetter(new[] { equipDetail }).Single();
				ParseUserMain(userMain, user, xpathConfig);
			}
			{
				var userProtections = xpathConfig.UserProtectionsGetter(new[] { equipDetail }).Single();
				ParseUserProtections(userProtections, user, xpathConfig);
			}
			ParsePaintedRank(content, user, config);
			return user;
		}

		private static void ParseUserMain(HtmlNode userMainNode, UserProfile user, ProfileParseConfig config)
		{
			var userMainArray = new[] { userMainNode };
			var userInfo = config.UserInfoGetter(userMainArray).Single();
			var userInfoArray = new[] { userInfo };

			var miiImageUri = config.MiiImageUriGetter(userInfoArray).Single();
			user.MiiImageUri = new Uri(miiImageUri);

			user.Name = config.MiiNameGetter(userInfoArray).Single();

			var rank = config.RankGetter(userInfoArray).Single();
			user.Rank = Convert.ToByte(rank);

			user.UdemaeAsString = config.UdemaeGetter(userInfoArray).Single();

			var weaponImage = config.WeaponImageGetter(userMainArray).Single();
			var weaponImageUris = ParseImage(weaponImage, config);
			user.WeaponImageUri = weaponImageUris.Item1;
			user.WeaponRetinaImageUri = weaponImageUris.Item2;
		}

		private static void ParseUserProtections(HtmlNode userProtectionsNode, UserProfile user, ProfileParseConfig config)
		{
			var userProtectionsArray = new[] { userProtectionsNode };

			var head = config.HeadGetter(userProtectionsArray).Single();
			user.HeadGear = ParseGear(head, config);

			var clothes = config.ClothesGetter(userProtectionsArray).Single();
			user.ClothesGear = ParseGear(clothes, config);

			var shoes = config.ShoesGetter(userProtectionsArray).Single();
			user.ShoesGear = ParseGear(shoes, config);
		}

		private static Gear ParseGear(HtmlNode gearNode, ProfileParseConfig config)
		{
			var gear = new Gear();
			var gearArray = new[] { gearNode };

			var gearImage = config.GearImageGetter(gearArray).Single();
			var gearImageUris = ParseImage(gearImage, config);
			gear.ImageUri = gearImageUris.Item1;
			gear.RetinaImageUri = gearImageUris.Item2;

			var gearPowerMainSvg = config.GearPowerMainSvgGetter(gearArray).Single();
			gear.GearPowerMainSvgUri = ParseImageUriFromStyle(gearPowerMainSvg, config);

			var gearPowerSub = config.GearPowerSubGetter(gearArray).Single();
			var gearPowerSubArray = new[] { gearPowerSub };

			var gearPowerSub1Svg = config.GearPowerSub1Getter(gearPowerSubArray).Single();
			gear.GearPowerSub1SvgUri = ParseImageUriFromStyle(gearPowerSub1Svg, config);

			try
			{
				var gearPowerSub2Svg = config.GearPowerSub2Getter(gearPowerSubArray).Single();
				gear.GearPowerSub2SvgUri = ParseImageUriFromStyle(gearPowerSub2Svg, config);

				var gearPowerSub3Svg = config.GearPowerSub3Getter(gearPowerSubArray).Single();
				gear.GearPowerSub3SvgUri = ParseImageUriFromStyle(gearPowerSub3Svg, config);
			}
			catch (ArgumentOutOfRangeException) { }

			return gear;
		}

		private static void ParsePaintedRank(HtmlNode content, UserProfile user, ProfileParseConfig config)
		{
			var contentArray = new[] { content };
			var paintedRankNodes = config.PaintedRankGetter(contentArray);
			foreach (var paintedRankNode in paintedRankNodes)
			{
				var paintedRankNodeArray = new[] { paintedRankNode };
				var imageNode = config.PaintedWeaponImageGetter(paintedRankNodeArray).Single();
				var imageUris = ParseImage(imageNode, config);

				var pointText = config.PaintedPointGetter(paintedRankNodeArray).Single();
				var point = Convert.ToUInt32(pointText);

				user._PaintedRank.Add(new PaintedRank(imageUris.Item1, imageUris.Item2, point));
			}
		}

		private static Tuple<Uri, Uri> ParseImage(HtmlNode imageNode, ProfileParseConfig config)
		{
			var containsImageUriText = imageNode.GetAttributeValue("style", string.Empty);
			var imageUri = ParseImageUriFromStyle(containsImageUriText, config);
			var containsRetinaImageUriText = imageNode.GetAttributeValue("data-retina-image", string.Empty);
			var retinaImageUriText = Regex.Match(containsRetinaImageUriText, config.RetinaImageUriFormat).Groups["uri"].Value;
			return Tuple.Create(imageUri, new Uri(config.ImageBaseUri, retinaImageUriText));
		}

		private static Uri ParseImageUriFromStyle(string styleText, ProfileParseConfig config)
		{
			var imageUriText = Regex.Match(styleText, config.ImageUriFormat).Groups["uri"].Value;
			return new Uri(config.ImageBaseUri, imageUriText);
		}

		public Task<UserProfile> GetProfileAsync() => this.GetProfileAsync(ProfileParseConfig.Default, CancellationToken.None);
		public Task<UserProfile> GetProfileAsync(CancellationToken cancellationToken) => this.GetProfileAsync(ProfileParseConfig.Default, cancellationToken);
		public Task<UserProfile> GetProfileAsync(ProfileParseConfig config) => this.GetProfileAsync(config, CancellationToken.None);
		public Task<UserProfile> GetProfileAsync(ProfileParseConfig config, CancellationToken cancellationToken)
		{
			if (config == null) throw new ArgumentNullException(nameof(config));

			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync(SplatoonConstantValues.PROFILE_URI_TEXT, cancellationToken)
				.ContinueWith(prevTask => ParseProfile(prevTask.Result, config));
		}

		public Task<UserProfile> GetProfileAsync(string friendHashID) => this.GetProfileAsync(friendHashID, ProfileParseConfig.Default, CancellationToken.None);
		public Task<UserProfile> GetProfileAsync(string friendHashID, CancellationToken cancellationToken) => this.GetProfileAsync(friendHashID, ProfileParseConfig.Default, cancellationToken);
		public Task<UserProfile> GetProfileAsync(string friendHashID, ProfileParseConfig config) => this.GetProfileAsync(friendHashID, config, CancellationToken.None);
		public Task<UserProfile> GetProfileAsync(string friendHashID, ProfileParseConfig config, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(friendHashID)) throw new ArgumentNullException(nameof(friendHashID));
			if (config == null) throw new ArgumentNullException(nameof(config));

			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync($"{SplatoonConstantValues.PROFILE_URI_TEXT}/{friendHashID}", cancellationToken)
				.ContinueWith(prevTask => ParseProfile(prevTask.Result, config), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
		}
	}
}
