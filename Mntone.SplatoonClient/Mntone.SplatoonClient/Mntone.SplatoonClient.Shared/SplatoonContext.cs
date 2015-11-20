using Mntone.NintendoNetworkHelper;
using Mntone.SplatoonClient.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

#if WINDOWS_APP
using Windows.Web.Http;
using Windows.Web.Http.Filters;
#else
using System.Net;
using System.Net.Http;
#endif

namespace Mntone.SplatoonClient
{
	public sealed partial class SplatoonContext : IDisposable
	{
		private bool _disposed = false;

#if WINDOWS_APP
		private HttpBaseProtocolFilter _filter = null;
		private HttpClient _client = null;
#else
		private HttpClientHandler _handler = null;
		private HttpClient _client = null;
#endif

		public SplatoonContext(string userName, string clientID, string sessionValue)
		{
			this.UserName = userName;
			this.ClientID = clientID;

			this.Initialize(sessionValue);
		}

		internal SplatoonContext(AccessToken accessToken)
			: this(accessToken.UserName, accessToken.ClientID, accessToken.SessionValue)
		{ }

		private void Initialize(string sessionValue)
		{
#if WINDOWS_APP
			this._filter = new HttpBaseProtocolFilter()
			{
				AllowAutoRedirect = false,
				AllowUI = false,
				AutomaticDecompression = true,
			};

			var cookie = new HttpCookie(SplatoonConstantValues.COOKIE_SESSION_NAME, SplatoonConstantValues.DOMAIN_URI_TEXT, "/")
			{
				Value = sessionValue,
				Secure = true,
				HttpOnly = true,
			};
            this._filter.CookieManager.SetCookie(cookie);
			this._client = new HttpClient(this._filter);
#else
			this._handler = new HttpClientHandler()
			{
				AllowAutoRedirect = false,
				AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
			};
			var cookie = $"{SplatoonConstantValues.COOKIE_SESSION_NAME}={sessionValue}; Path=/; Secure; HttpOnly";
			this._handler.CookieContainer.SetCookies(SplatoonConstantValues.DOMAIN_URI, cookie);
			this._client = new HttpClient(this._handler);
#endif
			this._client.DefaultRequestHeaders.Add("user-agent",
				!string.IsNullOrEmpty(this.AdditionalUserAgent)
					? $"{AssemblyInfo.QualifiedName}/{AssemblyInfo.Version} ({this.AdditionalUserAgent})"
					: $"{AssemblyInfo.QualifiedName}/{AssemblyInfo.Version}");
		}

		public Task SignOutAsync() => this.SignOutAsync(CancellationToken.None);
		public Task SignOutAsync(CancellationToken cancellationToken)
		{
			return this._client.Get2Async(SplatoonConstantValues.SIGN_OUT_URI, cancellationToken)
				.ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
					return this._client.Get2Async(result.Headers.Location, cancellationToken);
				}).Unwrap()
				.ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
#if WINDOWS_APP
					if (result.StatusCode != HttpStatusCode.Ok)
#else
					if (result.StatusCode != HttpStatusCode.OK)
#endif
					{
						throw new SplatoonClientException(Messages.IMPOSSIBLE);
					}
					return result;
				});
		}


#region Method

		private void AccessCheck()
		{
			if (this._disposed) throw new SplatoonClientException(Messages.DISPOSED_OBJECT);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (this._disposed) return;
			if (disposing) this.Release();
			this._disposed = true;
		}

		private void Release()
		{
			if (this._client != null)
			{
				this._client.Dispose();
#if WINDOWS_APP
				this._filter = null;
#else
				this._handler = null;
#endif
				this._client = null;
			}
		}

#endregion


#region Property

		public string UserName { get; }
		public string ClientID { get; }
		public string SessionValue
		{
#if WINDOWS_APP
			get { return SplatoonHelper.GetSessionValue2(this._filter.CookieManager); }
#else
			get { return SplatoonHelper.GetSessionValue(this._handler.CookieContainer); }
#endif
		}

		public string AdditionalUserAgent
		{
			get { return this._AdditionalUserAgent; }
			set
			{
				if (this._AdditionalUserAgent == value) return;

				this._AdditionalUserAgent = value;

				var sessionValue = this.SessionValue;
				this.Release();
				this.Initialize(sessionValue);
			}
		}
		private string _AdditionalUserAgent = null;

#endregion
	}
}
