using Mntone.NintendoNetworkHelper;
using Mntone.SplatoonClient.Internal;
using System;
using System.Net;
using System.Net.Http;

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

			this._clientHandler = new HttpClientHandler()
			{
				AllowAutoRedirect = false,
				AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
			};
			var cookie = new Cookie(SplatoonConstantValues.COOKIE_SESSION_NAME, sessionValue, "/", SplatoonConstantValues.DOMAIN_TEXT)
			{
				Secure = true,
				HttpOnly = true,
			};
			this._clientHandler.CookieContainer.Add(SplatoonConstantValues.DOMAIN_URI, cookie);
			this._client = new HttpClient(this._clientHandler, true);
			this._client.DefaultRequestHeaders.Add("user-agent",
				!string.IsNullOrEmpty(this.AdditionalUserAgent)
					? $"NintendoNetworkHelper/{AssemblyHelpers.GetAssemblyVersionText(this.GetType())} ({this.AdditionalUserAgent})"
					: $"NintendoNetworkHelper/{AssemblyHelpers.GetAssemblyVersionText(this.GetType())}");
		}

		internal SplatoonContext(AccessToken accessToken)
			: this(accessToken.UserName, accessToken.ClientID, accessToken.SessionValue)
		{ }


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
				this.Release();
			}
		}
		private string _AdditionalUserAgent = null;

		#endregion
	}
}
