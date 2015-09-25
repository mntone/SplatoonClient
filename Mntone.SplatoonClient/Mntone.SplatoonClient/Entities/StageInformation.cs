namespace Mntone.SplatoonClient.Entities
{
	public sealed class StageInformation
	{
		internal StageInformation(TimePeriod timePeriod, Stage[] regular, string rule, Stage[] ranked)
		{
			this.TimePeriod = timePeriod;
			this.RegularBattleStages = regular;
			this.RankedBattleRule = rule;
			this.RankedBattleStages = ranked;
		}

		/// <summary>
		/// Time period
		/// </summary>
		public TimePeriod TimePeriod { get; }

		/// <summary>
		/// Regular battle stages
		/// </summary>
		public Stage[] RegularBattleStages { get; }

		/// <summary>
		/// Ranked battle rule (ja-JP)
		/// </summary>
		public string RankedBattleRule { get; }

		/// <summary>
		/// Ranked battle stages
		/// </summary>
		public Stage[] RankedBattleStages { get; }
	}
}