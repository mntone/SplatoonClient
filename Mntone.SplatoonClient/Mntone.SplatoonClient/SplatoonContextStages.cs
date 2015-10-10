using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static IScheduleResponse ParseSchedule(string jsonData)
		{
			if (jsonData.Contains("\"festival\":true"))
				return JsonSerializerExtensions.Load<FestivalScheduleResponse>(jsonData);
			return JsonSerializerExtensions.Load<NormalScheduleResponse>(jsonData);
		}

		public Task<IScheduleResponse> GetScheduleAsync(string language = null)
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
