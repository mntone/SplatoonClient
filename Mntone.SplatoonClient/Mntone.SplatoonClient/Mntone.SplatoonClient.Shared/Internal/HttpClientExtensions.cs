using System;
using System.Threading;
using System.Threading.Tasks;

#if WINDOWS_APP
using Windows.Web.Http;
#else
using System.Net;
using System.Net.Http;
#endif

namespace Mntone.SplatoonClient.Internal
{
	internal static class HttpClientExtensions
	{
		public static Task<HttpResponseMessage> Get2Async(this HttpClient client, Uri uri, CancellationToken cancellationToken)
		{
#if WINDOWS_APP
			return client.GetAsync(uri).AsTask(cancellationToken);
#else
			return client.GetAsync(uri, cancellationToken);
#endif
		}

#if WINDOWS_APP
		public static Task<string> ReadAsString2Async(this IHttpContent content, CancellationToken cancellationToken) => content.ReadAsStringAsync().AsTask(cancellationToken);
#else
		public static Task<string> ReadAsString2Async(this HttpContent content, CancellationToken cancellationToken) => content.ReadAsStringAsync();
#endif

		public static Task<string> GetStringWithAccessCheckAsync(this HttpClient client, string uriText, CancellationToken cancellationToken) => client.GetStringWithAccessCheckAsync(new Uri(uriText), cancellationToken);
		public static Task<string> GetStringWithAccessCheckAsync(this HttpClient client, Uri uri, CancellationToken cancellationToken)
		{
			return client.Get2Async(uri, cancellationToken).ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
					AccessCheck(result);
					return result.Content.ReadAsString2Async(cancellationToken);
				}).Unwrap();
		}

		public static void AccessCheck(HttpResponseMessage response)
		{
			if (response.StatusCode == HttpStatusCode.Unauthorized) throw new SplatoonClientException(Messages.UNAUTHORIZED);
			if (response.StatusCode == HttpStatusCode.ServiceUnavailable) throw new SplatoonClientException(Messages.SERVICE_UNAVAILBLE);
		}
	}
}