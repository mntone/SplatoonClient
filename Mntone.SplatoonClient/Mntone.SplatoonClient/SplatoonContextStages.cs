using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static ScheduleResponse ParseSchedule(string jsonData)
			=> JsonSerializerExtensions.Load<ScheduleResponse>(jsonData);

		public Task<ScheduleResponse> GetScheduleAsync(string language = null)
		{
			this.AccessCheck();
			string uriText;
			if (language == null)
			{
				uriText = SplatoonConstantValues.SCHEDULES_URI_TEXT;
			}
			else
			{
				uriText = $"{SplatoonConstantValues.SCHEDULES_URI_TEXT}?locale={language}";
			}
			return this._client.GetStringWithAccessCheckAsync(uriText)
				.ContinueWith(prevTask => ParseSchedule(prevTask.Result));
		}
	}
}
