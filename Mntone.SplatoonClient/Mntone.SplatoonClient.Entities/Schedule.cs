using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class Schedule
	{
		private Schedule() { }

		internal Schedule(DateTimeOffset beginDateTime, DateTimeOffset endDateTime, string gachiRule, Stages stages)
		{
			this.BeginDateTime = beginDateTime;
			this.EndDateTime = endDateTime;
			this.GachiRule = gachiRule;
			this.Stages = stages;
		}

		/// <summary>
		/// Begin date time
		/// </summary>
		public DateTimeOffset BeginDateTime { get; private set; }

		[DataMember(Name = "datetime_begin", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string BeginDateTimeImpl
		{
			get { return this.BeginDateTime.ToFormattedString(); }
			set { this.BeginDateTime = value.ToDateTimeOffset(); }
		}

		/// <summary>
		/// End date time
		/// </summary>
		public DateTimeOffset EndDateTime { get; private set; }

		[DataMember(Name = "datetime_end", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string EndDateTimeImpl
		{
			get { return this.EndDateTime.ToFormattedString(); }
			set { this.EndDateTime = value.ToDateTimeOffset(); }
		}

		/// <summary>
		/// Ranked battle rule
		/// </summary>
		[DataMember(Name = "gachi_rule", IsRequired = true)]
		public string GachiRule { get; private set; }

		/// <summary>
		/// Stages
		/// </summary>
		[DataMember(Name = "stages", IsRequired = true)]
		public Stages Stages { get; private set; }
	}
}