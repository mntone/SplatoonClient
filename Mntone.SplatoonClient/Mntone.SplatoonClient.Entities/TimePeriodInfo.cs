using System;

namespace Mntone.SplatoonClient.Entities
{
	/// <summary>
	/// Time period information
	/// </summary>
	public sealed class TimePeriod
	{
		internal TimePeriod(DateTimeOffset beginTime, DateTimeOffset endTime)
		{
			this.BeginTime = beginTime;
			this.EndTime = endTime;
		}

		/// <summary>
		/// Begin time
		/// </summary>
		public DateTimeOffset BeginTime { get; }

		/// <summary>
		/// End time
		/// </summary>
		public DateTimeOffset EndTime { get; }
	}
}