using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static Friend[] ParseFriends(string jsonData)
			=> JsonSerializerExtensions.Load<Friend[]>(jsonData);

		public Task<Friend[]> GetFriendsAsync() => this.GetFriendsAsync(CancellationToken.None);
		public Task<Friend[]> GetFriendsAsync(CancellationToken cancellationToken)
		{
			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync(SplatoonConstantValues.FRIENDS_URI_TEXT, cancellationToken)
				.ContinueWith(prevTask => ParseFriends(prevTask.Result), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
		}
	}
}