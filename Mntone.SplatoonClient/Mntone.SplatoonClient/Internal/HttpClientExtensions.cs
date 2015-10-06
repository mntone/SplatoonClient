using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient.Internal
{
	internal static class HttpClientExtensions
	{
		public static Task<string> GetStringWithAccessCheckAsync(this HttpClient client, string uri)
		{
			return client.GetAsync(uri).ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
					if (result.StatusCode == HttpStatusCode.Unauthorized) throw new SplatoonClientException(Messages.UNAUTHORIZED);
					if (result.StatusCode == HttpStatusCode.ServiceUnavailable) throw new SplatoonClientException(Messages.SERVICE_UNAVAILBLE);
					return result.Content.ReadAsStringAsync();
				}).Unwrap();
		}
	}
}