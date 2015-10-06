using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class ScheduleResponse
	{
		private ScheduleResponse() { }

		internal ScheduleResponse(bool festival, Schedule[] schedule)
		{
			this.IsFestival = festival;
			this.Schedule = schedule;
		}

		/// <summary>
		/// Is festival
		/// </summary>
		[DataMember(Name = "festival", IsRequired = true)]
		public bool IsFestival { get; private set; }

		/// <summary>
		/// Schedule
		/// </summary>
		[DataMember(Name = "schedule", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
		public Schedule[] Schedule { get; private set; }
	}
}