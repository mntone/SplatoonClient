using HtmlAgilityPack;
using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static TimePeriod ParseTimePeriod(StageParseConfig config, string timePeriodText)
		{
			var times = timePeriodText.Split(new[] { config.TimePeriodSeparator }, StringSplitOptions.None).Select(s => s.Trim());
			var begin = DateTimeOffset.ParseExact(times.ElementAt(0), config.TimeFormat, null);
			var end = DateTimeOffset.ParseExact(times.ElementAt(1), config.TimeFormat, null);
			return new TimePeriod(begin, end);
		}

		private static Stage[] ParseStages(StageParseConfig config, IEnumerable<HtmlNode> stagesNode)
		{
			var buf = new List<Stage>();
			var map1 = config.Map1Getter(stagesNode);
			buf.Add(ParseStage(config, map1));

			var map2 = config.Map2Getter(stagesNode);
			buf.Add(ParseStage(config, map2));
			return buf.ToArray();
		}

		private static Stage ParseStage(StageParseConfig config, IEnumerable<HtmlNode> stageNode)
		{
			var baseUri = new Uri(config.MapImageBaseUri);
			var containsImageUriText = config.MapImageUriGetter(stageNode).Single();
			var imageUriText = Regex.Match(containsImageUriText, config.MapImageUriFormat).Groups["uri"].Value;
			var containsRetinaImageUriText = config.MapRetinaImageUriGetter(stageNode).Single();
			var retinaImageUriText = Regex.Match(containsRetinaImageUriText, config.MapRetinaImageUriFormat).Groups["uri"].Value;
			var name = config.MapNameGetter(stageNode).Single();
			return new Stage(name, new Uri(baseUri, imageUriText), new Uri(baseUri, retinaImageUriText));
		}

		private static StagesResponse ParseStages(string htmlData, StageParseConfig config)
		{
			var doc = new HtmlDocument();
			doc.Load(new StringReader(htmlData));

			var xpathConfig = config ?? StageParseConfig.Default;
			var content = xpathConfig.ContentRootGetter(new[] { doc.DocumentNode });

			StageInformation first = null;
			{
				var timePeriod = ParseTimePeriod(xpathConfig, xpathConfig.FirstStageTimePeriodGetter(content).Single());
				var regular = ParseStages(xpathConfig, xpathConfig.FirstRegularBattleStageGetter(content));
				var rankedNode = xpathConfig.FirstRankedBattleStageGetter(content);
				var rule = xpathConfig.RankedBattleRuleGetter(rankedNode).Single();
				var ranked = ParseStages(xpathConfig, rankedNode);
				first = new StageInformation(timePeriod, regular, rule, ranked);
			}

			StageInformation second = null;
			{
				var timePeriod = ParseTimePeriod(xpathConfig, xpathConfig.SecondStageTimePeriodGetter(content).Single());
				var regular = ParseStages(xpathConfig, xpathConfig.SecondRegularBattleStageGetter(content));
				var rankedNode = xpathConfig.SecondRankedBattleStageGetter(content);
				var rule = xpathConfig.RankedBattleRuleGetter(rankedNode).Single();
				var ranked = ParseStages(xpathConfig, rankedNode);
				second = new StageInformation(timePeriod, regular, rule, ranked);
			}

			StageInformation third = null;
			{
				var timePeriod = ParseTimePeriod(xpathConfig, xpathConfig.ThirdStageTimePeriodGetter(content).Single());
				var regular = ParseStages(xpathConfig, xpathConfig.ThirdRegularBattleStageGetter(content));
				var rankedNode = xpathConfig.ThirdRankedBattleStageGetter(content);
				var rule = xpathConfig.RankedBattleRuleGetter(rankedNode).Single();
				var ranked = ParseStages(xpathConfig, rankedNode);
				third = new StageInformation(timePeriod, regular, rule, ranked);
			}
			return new StagesResponse(new[] { first, second, third });
		}

		public Task<StagesResponse> GetStagesAsync(StageParseConfig config = null)
		{
			this.AccessCheck();
			return this._client.GetStringAsync(SplatoonConstantValues.STAGES_URI_TEXT)
				.ContinueWith(prevTask => ParseStages(prevTask.Result, config));
		}
	}
}
