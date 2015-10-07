using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static RankingResponse ParseRanking(string jsonData)
			=> JsonSerializerExtensions.Load<RankingResponse>(jsonData);

		public Task<RankingResponse> GetRankingAsync()
		{
			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync(SplatoonConstantValues.RANKING_URI_TEXT)
				.ContinueWith(prevTask => ParseRanking(prevTask.Result));
		}
	}
}