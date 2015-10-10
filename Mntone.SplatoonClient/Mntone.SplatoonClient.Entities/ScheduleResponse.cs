using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	public interface IScheduleResponse
	{
		/// <summary>
		/// Is festival
		/// </summary>
		bool IsFestival { get; }

		/// <summary>
		/// Schedule
		/// </summary>
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
		ISchedule[] Schedule { get; }
	}

	[DataContract]
	internal sealed class NormalScheduleResponse : IScheduleResponse
	{
		internal NormalScheduleResponse(NormalSchedule[] schedule)
		{
			this.ScheduleInternal = schedule;
		}

		public bool IsFestival => false;

		[DataMember(Name = "festival", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool IsFestivalInternal
		{
			get { return false; }
			set { if (value) throw new InvalidDataContractException(); }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
		public ISchedule[] Schedule => this.ScheduleInternal;

		[DataMember(Name = "schedule", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private NormalSchedule[] ScheduleInternal { get; set; }
	}

	[DataContract]
	internal sealed class FestivalScheduleResponse : IScheduleResponse
	{
		internal FestivalScheduleResponse(FestivalSchedule[] schedule)
		{
			this.ScheduleInternal = schedule;
		}

		public bool IsFestival => true;

		[DataMember(Name = "festival", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool IsFestivalInternal
		{
			get { return true; }
			set { if (!value) throw new InvalidDataContractException(); }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
		public ISchedule[] Schedule => this.ScheduleInternal;

		[DataMember(Name = "schedule", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private FestivalSchedule[] ScheduleInternal { get; set; }
	}
}