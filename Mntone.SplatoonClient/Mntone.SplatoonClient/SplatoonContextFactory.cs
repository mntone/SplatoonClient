﻿using System.Threading.Tasks;
using Mntone.NintendoNetworkHelper;
using Mntone.SplatoonClient.Internal;

namespace Mntone.SplatoonClient
{
	public static class SplatoonContextFactory
	{
		public static async Task<SplatoonContext> GetContextAsync(string username, string password)
		{
			var authorizer = new NintendoNetworkAuthorizer();
			var requestToken = await authorizer.GetRequestTokenAsync(SplatoonConstantValues.AUTH_FORWARD_URI).ConfigureAwait(false);
			var accessToken = await authorizer.Authorize(requestToken, new AuthenticationToken(username, password), SplatoonHelper.GetSessionValue).ConfigureAwait(false);
			var requestToken2 = await authorizer.GetRequestTokenAsync(SplatoonConstantValues.AUTH_FORWARD_URI).ConfigureAwait(false);
			var accessToken2 = await authorizer.Authorize(requestToken2, new AuthenticationToken(username, password), SplatoonHelper.GetSessionValue).ConfigureAwait(false);
			return new SplatoonContext(accessToken2);
		}
	}
}
