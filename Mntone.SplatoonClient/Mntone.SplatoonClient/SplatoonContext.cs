using Mntone.NintendoNetworkHelper;
using Mntone.SplatoonClient.Internal;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
	public sealed partial class SplatoonContext : IDisposable
	{
		private bool _disposed = false;

		private HttpClientHandler _clientHandler = null;
		private HttpClient _client = null;

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
			this._clientHandler = new HttpClientHandler()
			{
				AllowAutoRedirect = false,
				AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
			};
			var cookie = $"{SplatoonConstantValues.COOKIE_SESSION_NAME}={sessionValue}; Path=/; Secure; HttpOnly";
			this._clientHandler.CookieContainer.SetCookies(SplatoonConstantValues.DOMAIN_URI, cookie);
			this._client = new HttpClient(NintendoNetworkHelper.Internal.PatchedHttpClientHandler.PatchOrDefault(this._clientHandler));
			this._client.DefaultRequestHeaders.Add("user-agent",
				!string.IsNullOrEmpty(this.AdditionalUserAgent)
					? $"{AssemblyInfo.QualifiedName}/{AssemblyInfo.Version} ({this.AdditionalUserAgent})"
					: $"{AssemblyInfo.QualifiedName}/{AssemblyInfo.Version}");
		}

		public Task SignOutAsync()
		{
			return this._client.GetAsync(SplatoonConstantValues.SIGN_OUT_URI_TEXT)
				.ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
					return this._client.GetAsync(result.Headers.Location);
				}).Unwrap()
				.ContinueWith(prevTask =>
				{
					var result = prevTask.Result;
					if (result.StatusCode != HttpStatusCode.OK)
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
				this._clientHandler = null;
				this._client = null;
			}
		}

		#endregion


		#region Property

		public string UserName { get; }
		public string ClientID { get; }
		public string SessionValue
		{
			get { return SplatoonHelper.GetSessionValue(this._clientHandler.CookieContainer); }
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
