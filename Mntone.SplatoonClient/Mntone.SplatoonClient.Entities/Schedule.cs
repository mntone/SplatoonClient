using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	public interface ISchedule
	{
		/// <summary>
		/// Begin date time
		/// </summary>
		DateTimeOffset BeginDateTime { get; }

		/// <summary>
		/// End date time
		/// </summary>
		DateTimeOffset EndDateTime { get; }

		/// <summary>
		/// Ranked battle rule
		/// </summary>
		string GachiRule { get; }

		/// <summary>
		/// Stages
		/// </summary>
		IStages Stages { get; }

		/// <summary>
		/// Team alpha name
		/// </summary>
		string TeamAlphaName { get; }

		/// <summary>
		/// Team alpha name
		/// </summary>
		string TeamBravoName { get; }
	}

	[DataContract]
	internal abstract class Schedule : ISchedule
	{
		internal Schedule(DateTimeOffset beginDateTime, DateTimeOffset endDateTime)
		{
			this.BeginDateTime = beginDateTime;
			this.EndDateTime = endDateTime;
		}

		public DateTimeOffset BeginDateTime { get; private set; }

		[DataMember(Name = "datetime_begin", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string BeginDateTimeImpl
		{
			get { return this.BeginDateTime.ToFormattedString(); }
			set { this.BeginDateTime = value.ToDateTimeOffset(); }
		}

		public DateTimeOffset EndDateTime { get; private set; }

		[DataMember(Name = "datetime_end", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string EndDateTimeImpl
		{
			get { return this.EndDateTime.ToFormattedString(); }
			set { this.EndDateTime = value.ToDateTimeOffset(); }
		}

		public abstract string GachiRule { get; }
		public abstract IStages Stages { get; }
		public abstract string TeamAlphaName { get; }
		public abstract string TeamBravoName { get; }
	}

	[DataContract]
	internal sealed class NormalSchedule : Schedule
	{
		internal NormalSchedule(DateTimeOffset beginDateTime, DateTimeOffset endDateTime, string gachiRule, NormalStages stages)
			: base(beginDateTime, endDateTime)
		{
			this.GachiRuleInternal = gachiRule;
			this.StagesInternal = stages;
		}

		public override string GachiRule => this.GachiRuleInternal;

		[DataMember(Name = "gachi_rule")]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string GachiRuleInternal { get; set; }

		public override IStages Stages => this.StagesInternal;

		[DataMember(Name = "stages", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private NormalStages StagesInternal { get; set; }

		public override string TeamAlphaName => string.Empty;
		public override string TeamBravoName => string.Empty;
	}

	[DataContract]
	internal sealed class FestivalSchedule : Schedule
	{
		internal FestivalSchedule(DateTimeOffset beginDateTime, DateTimeOffset endDateTime, FestivalStages stages, string teamAlphaName, string teamBravoName)
			: base(beginDateTime, endDateTime)
		{
			this.StagesInternal = stages;
			this.TeamAlphaNameInternal = teamAlphaName;
			this.TeamBravoNameInternal = teamBravoName;
		}

		public override string GachiRule => string.Empty;

		public override IStages Stages => this.StagesInternal;

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private FestivalStages StagesInternal { get; set; }

		[DataMember(Name = "stages", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Stage[] StagesImpl
		{
			get { return this.StagesInternal?.Regular; }
			set { this.StagesInternal = new FestivalStages(value); }
		}

		public override string TeamAlphaName => this.TeamAlphaNameInternal;

		[DataMember(Name = "team_alpha_name", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string TeamAlphaNameInternal { get; set; }

		public override string TeamBravoName => this.TeamBravoNameInternal;

		[DataMember(Name = "team_bravo_name", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string TeamBravoNameInternal { get; set; }
	}
}