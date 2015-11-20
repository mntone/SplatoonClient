using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System;
using System.Threading;
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

		public Task<IScheduleResponse> GetScheduleAsync() => this.GetScheduleAsync(CancellationToken.None);
		public Task<IScheduleResponse> GetScheduleAsync(CancellationToken cancellationToken)
		{
			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync(SplatoonConstantValues.SCHEDULES_URI_TEXT, cancellationToken)
				.ContinueWith(prevTask => ParseSchedule(prevTask.Result));
		}

		public Task<IScheduleResponse> GetScheduleAsync(string language) => this.GetScheduleAsync(language, CancellationToken.None);
		public Task<IScheduleResponse> GetScheduleAsync(string language, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(language)) throw new ArgumentNullException(nameof(language));

			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync($"{SplatoonConstantValues.SCHEDULES_URI_TEXT}?locale={language}", cancellationToken)
				.ContinueWith(prevTask => ParseSchedule(prevTask.Result));
		}
	}
}
