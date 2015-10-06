using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static ScheduleResponse ParseSchedule(string jsonData)
			=> JsonSerializerExtensions.Load<ScheduleResponse>(jsonData);

		public Task<ScheduleResponse> GetScheduleAsync()
		{
			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync(SplatoonConstantValues.SCHEDULES_URI_TEXT)
				.ContinueWith(prevTask => ParseSchedule(prevTask.Result));
		}
	}
}
