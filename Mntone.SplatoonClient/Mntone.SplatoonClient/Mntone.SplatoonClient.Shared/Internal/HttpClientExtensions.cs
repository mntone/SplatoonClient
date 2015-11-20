using System;
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
		public static Task<HttpResponseMessage> Get2Async(this HttpClient client, Uri uri)
		{
#if WINDOWS_APP
			return client.GetAsync(uri).AsTask();
#else
			return client.GetAsync(uri);
#endif
		}

		public static Task<string> GetString2Async(this HttpClient client, Uri uri)
		{
#if WINDOWS_APP
			return client.GetStringAsync(uri).AsTask();
#else
			return client.GetStringAsync(uri);
#endif
		}

#if WINDOWS_APP
		public static Task<string> ReadAsString2Async(this IHttpContent content)
		{
			return content.ReadAsStringAsync().AsTask();
		}
#else
		public static Task<string> ReadAsString2Async(this HttpContent content)
		{
			return content.ReadAsStringAsync();
		}
#endif

		public static Task<string> GetStringWithAccessCheckAsync(this HttpClient client, string uriText)
		{
			return client.Get2Async(new Uri(uriText)).ContinueWith(prevTask =>
			{
				var result = prevTask.Result;
				AccessCheck(result);
				return result.Content.ReadAsString2Async();
			}).Unwrap();
		}

		public static Task<string> GetStringWithAccessCheckAsync(this HttpClient client, Uri uri)
		{
			return client.Get2Async(uri).ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
					AccessCheck(result);
					return result.Content.ReadAsString2Async();
				}).Unwrap();
		}

		public static void AccessCheck(HttpResponseMessage response)
		{
			if (response.StatusCode == HttpStatusCode.Unauthorized) throw new SplatoonClientException(Messages.UNAUTHORIZED);
			if (response.StatusCode == HttpStatusCode.ServiceUnavailable) throw new SplatoonClientException(Messages.SERVICE_UNAVAILBLE);
		}
	}
}