using System.Linq;
using System.Net;

namespace Mntone.SplatoonClient.Internal
{
	internal static class SplatoonHelper
	{
		public static string GetSessionValue(CookieContainer cookies)
		{
			var cookie = cookies.GetCookies(SplatoonConstantValues.DOMAIN_URI)
				.Cast<Cookie>()
				.Where(c => c.Name == SplatoonConstantValues.COOKIE_SESSION_NAME && c.Path == "/" && c.Secure && c.HttpOnly)
				.OrderByDescending(c => c.Expires.Ticks)
				.First();
			return cookie.Value;
		}
	}
}