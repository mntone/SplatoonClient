using Mntone.SplatoonClient.Entities;
using Mntone.SplatoonClient.Internal;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	partial class SplatoonContext
	{
		private static Friend[] ParseFriends(string jsonData)
			=> JsonSerializerExtensions.Load<Friend[]>(jsonData);

		public Task<Friend[]> GetFriendsAsync()
		{
			this.AccessCheck();
			return this.Client.GetStringAsync(SplatoonConstantValues.FRIENDS_URI_TEXT)
				.ContinueWith(prevTask => ParseFriends(prevTask.Result));
		}
	}
}