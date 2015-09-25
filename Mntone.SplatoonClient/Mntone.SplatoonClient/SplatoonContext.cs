using Mntone.NintendoNetworkHelper;
using Mntone.SplatoonClient.Internal;
using System;
using System.Net;
using System.Net.Http;

namespace Mntone.SplatoonClient
{
	public sealed partial class SplatoonContext : IDisposable
	{
		private bool _isEnabled = true;

		public SplatoonContext(string userName, string clientID, string sessionValue)
		{
			this.UserName = userName;
			this.ClientID = clientID;

			this.ClientHandler = new HttpClientHandler()
			{
				AllowAutoRedirect = false,
				AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
			};
			var cookie = new Cookie(SplatoonConstantValues.COOKIE_SESSION_NAME, sessionValue, "/", SplatoonConstantValues.DOMAIN_TEXT)
			{
				Secure = true,
				HttpOnly = true,
			};
			this.ClientHandler.CookieContainer.Add(SplatoonConstantValues.DOMAIN_URI, cookie);
			this.Client = new HttpClient(this.ClientHandler, true);
		}

		internal SplatoonContext(AccessToken accessToken)
			: this(accessToken.UserName, accessToken.ClientID, accessToken.SessionValue)
		{ }


		#region Method

		private void AccessCheck()
		{
			if (!this._isEnabled)
			{
				throw new SplatoonClientException(Messages.DISPOSED_OBJECT);
			}
		}

		public void Dispose()
		{
			this._isEnabled = false;
			this.Client.Dispose();
		}

		#endregion


		#region Property

		public string UserName { get; }
		public string ClientID { get; }
		public string SessionValue
		{
			get { return SplatoonHelper.GetSessionValue(this.ClientHandler.CookieContainer); }
		}

		private HttpClientHandler ClientHandler { get; }
		private HttpClient Client { get; }

		#endregion
	}
}
