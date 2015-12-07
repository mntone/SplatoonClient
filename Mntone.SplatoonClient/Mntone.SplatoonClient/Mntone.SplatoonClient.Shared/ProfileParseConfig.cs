using HtmlAgilityPack;
using Mntone.SplatoonClient.Shared.Internal;
using Mntone.XPath;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient
{
	[DataContract]
	public sealed class ProfileParseConfig
	{
		private static HtmlAgilityXPathRetriveConfig RetriverConfig { get; } = HtmlAgilityXPathRetriveConfig.Instance;

		private Func<IEnumerable<HtmlNode>, IEnumerable<T>> SetValue<T>(ref string storage, string value)
		{
			if (object.Equals(storage, value))
			{
				return null;
			}

			storage = value;
			return XPathExpression.Compile<HtmlNode, T>(value, RetriverConfig);
		}

		/// <summary>
		/// Content root
		/// </summary>
		[DataMember(Name = "content_root")]
		public string ContentRootXPath
		{
			get { return this._ContentRootXPath; }
			set { this.ContentRootGetter = this.SetValue<HtmlNode>(ref this._ContentRootXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _ContentRootXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> ContentRootGetter { get; set; }

		/// <summary>
		/// Equip detail
		/// </summary>
		[DataMember(Name = "equip_detail")]
		public string EquipDetailXPath
		{
			get { return this._EquipDetailXPath; }
			set { this.EquipDetailGetter = this.SetValue<HtmlNode>(ref this._EquipDetailXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _EquipDetailXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> EquipDetailGetter { get; set; }

		/// <summary>
		/// User main
		/// </summary>
		[DataMember(Name = "user_main")]
		public string UserMainXPath
		{
			get { return this._UserMainXPath; }
			set { this.UserMainGetter = this.SetValue<HtmlNode>(ref this._UserMainXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _UserMainXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> UserMainGetter { get; set; }

		/// <summary>
		/// User info
		/// </summary>
		[DataMember(Name = "user_info")]
		public string UserInfoXPath
		{
			get { return this._UserInfoXPath; }
			set { this.UserInfoGetter = this.SetValue<HtmlNode>(ref this._UserInfoXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _UserInfoXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> UserInfoGetter { get; set; }

		/// <summary>
		/// Mii image uri
		/// </summary>
		[DataMember(Name = "mii_image_uri")]
		public string MiiImageUriXPath
		{
			get { return this._MiiImageUriXPath; }
			set { this.MiiImageUriGetter = this.SetValue<string>(ref this._MiiImageUriXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _MiiImageUriXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> MiiImageUriGetter { get; set; }

		/// <summary>
		/// Mii name
		/// </summary>
		[DataMember(Name = "mii_name")]
		public string MiiNameXPath
		{
			get { return this._MiiNameXPath; }
			set { this.MiiNameGetter = this.SetValue<string>(ref this._MiiNameXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _MiiNameXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> MiiNameGetter { get; set; }

		/// <summary>
		/// Rank
		/// </summary>
		[DataMember(Name = "rank")]
		public string RankXPath
		{
			get { return this._RankXPath; }
			set { this.RankGetter = this.SetValue<string>(ref this._RankXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _RankXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> RankGetter { get; set; }

		/// <summary>
		/// Udemae
		/// </summary>
		[DataMember(Name = "udemae")]
		public string UdemaeXPath
		{
			get { return this._UdemaeXPath; }
			set { this.UdemaeGetter = this.SetValue<string>(ref this._UdemaeXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _UdemaeXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> UdemaeGetter { get; set; }

		/// <summary>
		/// Weapon image
		/// </summary>
		[DataMember(Name = "weapon_image")]
		public string WeaponImageXPath
		{
			get { return this._WeaponImageXPath; }
			set { this.WeaponImageGetter = this.SetValue<HtmlNode>(ref this._WeaponImageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _WeaponImageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> WeaponImageGetter { get; set; }

		/// <summary>
		/// User protections
		/// </summary>
		[DataMember(Name = "user_protections")]
		public string UserProtectionsXPath
		{
			get { return this._UserProtectionsXPath; }
			set { this.UserProtectionsGetter = this.SetValue<HtmlNode>(ref this._UserProtectionsXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _UserProtectionsXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> UserProtectionsGetter { get; set; }
		
		/// <summary>
		/// Head
		/// </summary>
		[DataMember(Name = "head")]
		public string HeadXPath
		{
			get { return this._HeadXPath; }
			set { this.HeadGetter = this.SetValue<HtmlNode>(ref this._HeadXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _HeadXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> HeadGetter { get; set; }

		/// <summary>
		/// Clothes
		/// </summary>
		[DataMember(Name = "clothes")]
		public string ClothesXPath
		{
			get { return this._ClothesXPath; }
			set { this.ClothesGetter = this.SetValue<HtmlNode>(ref this._ClothesXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _ClothesXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> ClothesGetter { get; set; }

		/// <summary>
		/// Shoes
		/// </summary>
		[DataMember(Name = "shoes")]
		public string ShoesXPath
		{
			get { return this._ShoesXPath; }
			set { this.ShoesGetter = this.SetValue<HtmlNode>(ref this._ShoesXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _ShoesXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> ShoesGetter { get; set; }

		/// <summary>
		/// Gear image
		/// </summary>
		[DataMember(Name = "gear_image")]
		public string GearImageXPath
		{
			get { return this._GearImageXPath; }
			set { this.GearImageGetter = this.SetValue<HtmlNode>(ref this._GearImageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _GearImageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> GearImageGetter { get; set; }

		/// <summary>
		/// Gear power main
		/// </summary>
		[DataMember(Name = "gear_power_main_svg")]
		public string GearPowerMainSvgXPath
		{
			get { return this._GearPowerMainSvgXPath; }
			set { this.GearPowerMainSvgGetter = this.SetValue<string>(ref this._GearPowerMainSvgXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _GearPowerMainSvgXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> GearPowerMainSvgGetter { get; set; }

		/// <summary>
		/// Gear power sub
		/// </summary>
		[DataMember(Name = "gear_power_sub")]
		public string GearPowerSubXPath
		{
			get { return this._GearPowerSubXPath; }
			set { this.GearPowerSubGetter = this.SetValue<HtmlNode>(ref this._GearPowerSubXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _GearPowerSubXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> GearPowerSubGetter { get; set; }

		/// <summary>
		/// Gear power sub1
		/// </summary>
		[DataMember(Name = "gear_power_sub1")]
		public string GearPowerSub1XPath
		{
			get { return this._GearPowerSub1XPath; }
			set { this.GearPowerSub1Getter = this.SetValue<string>(ref this._GearPowerSub1XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _GearPowerSub1XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> GearPowerSub1Getter { get; set; }

		/// <summary>
		/// Gear power sub2
		/// </summary>
		[DataMember(Name = "gear_power_sub2")]
		public string GearPowerSub2XPath
		{
			get { return this._GearPowerSub2XPath; }
			set { this.GearPowerSub2Getter = this.SetValue<string>(ref this._GearPowerSub2XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _GearPowerSub2XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> GearPowerSub2Getter { get; set; }

		/// <summary>
		/// Gear power sub3
		/// </summary>
		[DataMember(Name = "gear_power_sub3")]
		public string GearPowerSub3XPath
		{
			get { return this._GearPowerSub3XPath; }
			set { this.GearPowerSub3Getter = this.SetValue<string>(ref this._GearPowerSub3XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _GearPowerSub3XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> GearPowerSub3Getter { get; set; }
		
		/// <summary>
		/// Painted rank
		/// </summary>
		[DataMember(Name = "painted_rank")]
		public string PaintedRankXPath
		{
			get { return this._PaintedRankXPath; }
			set { this.PaintedRankGetter = this.SetValue<HtmlNode>(ref this._PaintedRankXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _PaintedRankXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> PaintedRankGetter { get; set; }

		/// <summary>
		/// Painted weapon image
		/// </summary>
		[DataMember(Name = "painted_weapon_image")]
		public string PaintedWeaponImageXPath
		{
			get { return this._PaintedWeaponImageXPath; }
			set { this.PaintedWeaponImageGetter = this.SetValue<HtmlNode>(ref this._PaintedWeaponImageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _PaintedWeaponImageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> PaintedWeaponImageGetter { get; set; }

		/// <summary>
		/// Painted point
		/// </summary>
		[DataMember(Name = "painted_point")]
		public string PaintedPointXPath
		{
			get { return this._PaintedPointXPath; }
			set { this.PaintedPointGetter = this.SetValue<string>(ref this._PaintedPointXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _PaintedPointXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> PaintedPointGetter { get; set; }

		/// <summary>
		/// Image uri format
		/// </summary>
		[DataMember(Name = "image_uri_format")]
		public string ImageUriFormat { get; set; }

		/// <summary>
		/// Retina image uri format
		/// </summary>
		[DataMember(Name = "retina_image_uri_format")]
		public string RetinaImageUriFormat { get; set; }

		/// <summary>
		/// Image base uri
		/// </summary>
		[DataMember(Name = "image_base_uri")]
		public Uri ImageBaseUri { get; set; }


		public static ProfileParseConfig Default
		{
			get
			{
				if (_Default == null)
				{
					_Default = new ProfileParseConfig()
					{
						ContentRootXPath = "/html/body/div[@class=\"ika-wrapper equipment\"]/div[@class=\"do\"]/div[@class=\"contents\"]",
						EquipDetailXPath = "/div[@class=\"equip-detail\"]",
						UserMainXPath = "/div[@class=\"equip-user-main\"]",
						UserInfoXPath = "/div[@class=\"equip-user-info\"]",
						MiiImageUriXPath = "/section[@class=\"user-profile\"]/div[@class=\"profile-mii icon-mii\"]/img/@src",
						MiiNameXPath = "/section[@class=\"user-profile\"]/h2/text()",
						RankXPath = "/section[@class=\"user-status\"][1]/p/text()",
						UdemaeXPath = "/section[@class=\"user-status\"][2]/p/text()",
						WeaponImageXPath = "/div[@class=\"equip-user-weapon\"]/div",

						UserProtectionsXPath = "/div[@class=\"equip-user-protections\"]",
						HeadXPath = "/div[@class=\"equip-head equip-protective\"]",
						ClothesXPath = "/div[@class=\"equip-clothes equip-protective\"]",
						ShoesXPath = "/div[@class=\"equip-shoes equip-protective\"]",
						GearImageXPath = "/div[1]",
						GearPowerMainSvgXPath = "/div[@class=\"equip-gearpower-default equip-gearpower-slot\"]/div/@style",
						GearPowerSubXPath = "/ul[@class=\"equip-gearpower-custom\"]",
						GearPowerSub1XPath = "/li[1]/div/@style",
						GearPowerSub2XPath = "/li[2]/div/@style",
						GearPowerSub3XPath = "/li[3]/div/@style",

						PaintedRankXPath = "/div[@class=\"equip-painted\"]/ol[@class=\"equip-painted-rank\"]/li",
						PaintedWeaponImageXPath = "/div[@class=\"equip-painted-weapon\"]/div",
						PaintedPointXPath = "/div[@class=\"equip-painted-point-number\"]/text()",

						ImageUriFormat = "background-image:\\s*?url\\(&\\#39;(?<uri>.*?)&\\#39;\\)",
						RetinaImageUriFormat = @"^(?<uri>.*?)$",
						ImageBaseUri = new Uri("https://splatoon.nintendo.net/"),
					};
				}
				return _Default;
			}
		}
		private static ProfileParseConfig _Default = null;
	}
}
