using HtmlAgilityPack;
using Mntone.SplatoonClient.Internal.XPath;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient
{
	[DataContract]
	public sealed class StageParseConfig
	{
		private HtmlAgilityXPathRetriveConfig RetriverConfig { get; } = new HtmlAgilityXPathRetriveConfig();

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
		/// Time period of the first stage
		/// </summary>
		[DataMember(Name = "first_stage_time_period")]
		public string FirstStageTimePeriodXPath
		{
			get { return this._FirstStageTimePeriodXPath; }
			set { this.FirstStageTimePeriodGetter = this.SetValue<string>(ref this._FirstStageTimePeriodXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FirstStageTimePeriodXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> FirstStageTimePeriodGetter { get; set; }

		/// <summary>
		/// The first regular battle stage
		/// </summary>
		[DataMember(Name = "first_regular_battle_stage")]
		public string FirstRegularBattleStageXPath
		{
			get { return this._FirstRegularBattleStageXPath; }
			set { this.FirstRegularBattleStageGetter = this.SetValue<HtmlNode>(ref this._FirstRegularBattleStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FirstRegularBattleStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> FirstRegularBattleStageGetter { get; set; }

		/// <summary>
		/// The first ranked battle stage
		/// </summary>
		[DataMember(Name = "first_ranked_battle_stage")]
		public string FirstRankedBattleStageXPath
		{
			get { return this._FirstRankedBattleStageXPath; }
			set { this.FirstRankedBattleStageGetter = this.SetValue<HtmlNode>(ref this._FirstRankedBattleStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FirstRankedBattleStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> FirstRankedBattleStageGetter { get; set; }

		/// <summary>
		/// Time period of the second stage
		/// </summary>
		[DataMember(Name = "second_stage_time_period")]
		public string SecondStageTimePeriodXPath
		{
			get { return this._SecondStageTimePeriodXPath; }
			set { this.SecondStageTimePeriodGetter = this.SetValue<string>(ref this._SecondStageTimePeriodXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _SecondStageTimePeriodXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> SecondStageTimePeriodGetter { get; set; }

		/// <summary>
		/// The second regular battle stage
		/// </summary>
		[DataMember(Name = "second_regular_battle_stage")]
		public string SecondRegularBattleStageXPath
		{
			get { return this._SecondRegularBattleStageXPath; }
			set { this.SecondRegularBattleStageGetter = this.SetValue<HtmlNode>(ref this._SecondRegularBattleStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _SecondRegularBattleStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> SecondRegularBattleStageGetter { get; set; }

		/// <summary>
		/// The second ranked battle stage
		/// </summary>
		[DataMember(Name = "second_ranked_battle_stage")]
		public string SecondRankedBattleStageXPath
		{
			get { return this._SecondRankedBattleStageXPath; }
			set { this.SecondRankedBattleStageGetter = this.SetValue<HtmlNode>(ref this._SecondRankedBattleStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _SecondRankedBattleStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> SecondRankedBattleStageGetter { get; set; }

		/// <summary>
		/// Time period of the third stage
		/// </summary>
		[DataMember(Name = "third_stage_time_period")]
		public string ThirdStageTimePeriodXPath
		{
			get { return this._ThirdStageTimePeriodXPath; }
			set { this.ThirdStageTimePeriodGetter = this.SetValue<string>(ref this._ThirdStageTimePeriodXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _ThirdStageTimePeriodXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> ThirdStageTimePeriodGetter { get; set; }

		/// <summary>
		/// The third regular battle stage
		/// </summary>
		[DataMember(Name = "third_regular_battle_stage")]
		public string ThirdRegularBattleStageXPath
		{
			get { return this._ThirdRegularBattleStageXPath; }
			set { this.ThirdRegularBattleStageGetter = this.SetValue<HtmlNode>(ref this._ThirdRegularBattleStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _ThirdRegularBattleStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> ThirdRegularBattleStageGetter { get; set; }

		/// <summary>
		/// The third ranked battle stage
		/// </summary>
		[DataMember(Name = "third_ranked_battle_stage")]
		public string ThirdRankedBattleStageXPath
		{
			get { return this._ThirdRankedBattleStageXPath; }
			set { this.ThirdRankedBattleStageGetter = this.SetValue<HtmlNode>(ref this._ThirdRankedBattleStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _ThirdRankedBattleStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> ThirdRankedBattleStageGetter { get; set; }

		/// <summary>
		/// Time period of festival
		/// </summary>
		[DataMember(Name = "festival_time_period")]
		public string FestivalTimePeriodXPath
		{
			get { return this._FestivalTimePeriodXPath; }
			set { this.FestivalTimePeriodGetter = this.SetValue<string>(ref this._FestivalTimePeriodXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FestivalTimePeriodXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> FestivalTimePeriodGetter { get; set; }

		/// <summary>
		/// Festival stage
		/// </summary>
		[DataMember(Name = "festival_stage")]
		public string FestivalStageXPath
		{
			get { return this._FestivalStageXPath; }
			set { this.FestivalStageGetter = this.SetValue<HtmlNode>(ref this._FestivalStageXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FestivalStageXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> FestivalStageGetter { get; set; }

		/// <summary>
		/// Festival team 1
		/// </summary>
		[DataMember(Name = "festival_team1")]
		public string FestivalTeam1XPath
		{
			get { return this._FestivalTeam1XPath; }
			set { this.FestivalTeam1Getter = this.SetValue<string>(ref this._FestivalTeam1XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FestivalTeam1XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> FestivalTeam1Getter { get; set; }

		/// <summary>
		/// Festival team 2
		/// </summary>
		[DataMember(Name = "festival_team2")]
		public string FestivalTeam2XPath
		{
			get { return this._FestivalTeam2XPath; }
			set { this.FestivalTeam2Getter = this.SetValue<string>(ref this._FestivalTeam2XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _FestivalTeam2XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> FestivalTeam2Getter { get; set; }

		/// <summary>
		/// Time period separator
		/// </summary>
		[DataMember(Name = "time_period_separator")]
		public string TimePeriodSeparator { get; set; }

		/// <summary>
		/// Time format
		/// </summary>
		[DataMember(Name = "time_format")]
		public string TimeFormat { get; set; }

		/// <summary>
		/// Ranked battle rule
		/// </summary>
		[DataMember(Name = "ranked_battle_rule")]
		public string RankedBattleRuleXPath
		{
			get { return this._RankedBattleRuleXPath; }
			set { this.RankedBattleRuleGetter = this.SetValue<string>(ref this._RankedBattleRuleXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _RankedBattleRuleXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> RankedBattleRuleGetter { get; set; }

		/// <summary>
		/// Map 1
		/// </summary>
		[DataMember(Name = "map1")]
		public string Map1XPath
		{
			get { return this._Map1XPath; }
			set { this.Map1Getter = this.SetValue<HtmlNode>(ref this._Map1XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Map1XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> Map1Getter { get; set; }

		/// <summary>
		/// Map 2
		/// </summary>
		[DataMember(Name = "map2")]
		public string Map2XPath
		{
			get { return this._Map2XPath; }
			set { this.Map2Getter = this.SetValue<HtmlNode>(ref this._Map2XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Map2XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> Map2Getter { get; set; }

		/// <summary>
		/// Map 3
		/// </summary>
		[DataMember(Name = "map3")]
		public string Map3XPath
		{
			get { return this._Map3XPath; }
			set { this.Map3Getter = this.SetValue<HtmlNode>(ref this._Map3XPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Map3XPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<HtmlNode>> Map3Getter { get; set; }

		/// <summary>
		/// Map image uri
		/// </summary>
		[DataMember(Name = "map_image_uri")]
		public string MapImageUriXPath
		{
			get { return this._MapImageUriXPath; }
			set { this.MapImageUriGetter = this.SetValue<string>(ref this._MapImageUriXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _MapImageUriXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> MapImageUriGetter { get; set; }

		/// <summary>
		/// Map retina image uri
		/// </summary>
		[DataMember(Name = "map_retina_image_uri")]
		public string MapRetinaImageUriXPath
		{
			get { return this._MapRetinaImageUriXPath; }
			set { this.MapRetinaImageUriGetter = this.SetValue<string>(ref this._MapRetinaImageUriXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _MapRetinaImageUriXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> MapRetinaImageUriGetter { get; set; }

		/// <summary>
		/// Map name
		/// </summary>
		[DataMember(Name = "map_name")]
		public string MapNameXPath
		{
			get { return this._MapNameXPath; }
			set { this.MapNameGetter = this.SetValue<string>(ref this._MapNameXPath, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _MapNameXPath;
		public Func<IEnumerable<HtmlNode>, IEnumerable<string>> MapNameGetter { get; set; }

		/// <summary>
		/// Map image uri format
		/// </summary>
		[DataMember(Name = "map_image_uri_format")]
		public string MapImageUriFormat { get; set; }

		/// <summary>
		/// Map retina image uri format
		/// </summary>
		[DataMember(Name = "map_retina_image_uri_format")]
		public string MapRetinaImageUriFormat { get; set; }

		/// <summary>
		/// Map image base uri
		/// </summary>
		[DataMember(Name = "map_image_base_uri")]
		public string MapImageBaseUri { get; set; }


		private Func<IEnumerable<HtmlNode>, IEnumerable<T>> SetValue<T>(ref string storage, string value)
		{
			if (object.Equals(storage, value))
			{
				return null;
			}

			storage = value;
			return XPathExpression.Compile<HtmlNode, T>(value, RetriverConfig);
		}

		public static StageParseConfig Default
		{
			get
			{
				var result = new StageParseConfig()
				{
					ContentRootXPath = "/html/body/div[@class=\"ika-wrapper stage\"]/div[@class=\"do\"]/div[@class=\"contents\"]",
					FirstStageTimePeriodXPath = "/span[1]/text()",
					FirstRegularBattleStageXPath = "/div[1]",
					FirstRankedBattleStageXPath = "/div[2]",
					SecondStageTimePeriodXPath = "/span[2]/text()",
					SecondRegularBattleStageXPath = "/div[3]",
					SecondRankedBattleStageXPath = "/div[4]",
					ThirdStageTimePeriodXPath = "/span[3]/text()",
					ThirdRegularBattleStageXPath = "/div[5]",
					ThirdRankedBattleStageXPath = "/div[6]",
					FestivalTimePeriodXPath = "/span[@class=\"stage-schedule\"]/text()",
					FestivalStageXPath = "/div[@class=\"stage-list festival-stage-list\"]",
					FestivalTeam1XPath = "/span[@class=\"festival-teams\"]/span[1]/text()",
					FestivalTeam2XPath = "/span[@class=\"festival-teams\"]/span[2]/text()",
					TimePeriodSeparator = "~",
					TimeFormat = "M'/'d' 'H':'mm",
					RankedBattleRuleXPath = "/div[@class=\"match-rule\"]/span[@class=\"rule-description\"]/text()",
					Map1XPath = "/div[@class=\"map-type\"]/div[1]",
					Map2XPath = "/div[@class=\"map-type\"]/div[2]",
					Map3XPath = "/div[@class=\"map-type second\"]/div[1]",
					MapImageUriXPath = "/span[1]/@style",
					MapRetinaImageUriXPath = "/span[1]/@data-retina-image",
					MapNameXPath = "/span[2]/text()",
					MapImageUriFormat = "background-image:\\s*?url\\(&\\#39;(?<uri>.*?)&\\#39;\\)",
					MapRetinaImageUriFormat = @"^(?<uri>.*?)$",
					MapImageBaseUri = "https://splatoon.nintendo.net/",
				};
				return result;
			}
		}
	}
}