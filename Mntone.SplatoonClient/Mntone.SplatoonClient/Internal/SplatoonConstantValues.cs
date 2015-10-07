using System;

namespace Mntone.SplatoonClient.Internal
{
	internal sealed class SplatoonConstantValues
	{
		public const string DOMAIN_TEXT = "splatoon.nintendo.net";

		public const string DOMAIN_URI_TEXT = "https://" + DOMAIN_TEXT + "/";
		public static readonly Uri DOMAIN_URI = new Uri(DOMAIN_URI_TEXT);

		public const string AUTH_FORWARD_URI_TEXT = DOMAIN_URI_TEXT + "users/auth/nintendo";
		public static readonly Uri AUTH_FORWARD_URI = new Uri(AUTH_FORWARD_URI_TEXT);

		public const string COOKIE_SESSION_NAME = "_wag_session";

		public const string SIGN_OUT_URI_TEXT = DOMAIN_URI_TEXT + "sign_out";
		public const string FRIENDS_URI_TEXT = DOMAIN_URI_TEXT + "friend_list/index.json";
		public const string RANKING_URI_TEXT = DOMAIN_URI_TEXT + "ranking/index.json";
		public const string SCHEDULES_URI_TEXT = DOMAIN_URI_TEXT + "schedule/index.json";
	}
}