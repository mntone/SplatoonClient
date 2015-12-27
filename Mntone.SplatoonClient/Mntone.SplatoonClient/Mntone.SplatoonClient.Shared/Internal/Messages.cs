namespace Mntone.SplatoonClient.Internal
{
	internal sealed class Messages
	{
		public const string UNKOWN = "Unknown error.";
		public const string PARSE_ERROR = "Parse error.";
		public const string DISPOSED_OBJECT = "You use disposed object. You must not use it.";
		public const string IMPOSSIBLE = "This operation is impossible.";
		public const string UNAUTHORIZED = "Response status code does not indicate success: 401 (Unauthorized).";
		public const string SERVICE_UNAVAILBLE = "Response status code does not indicate success: 503 (Service Unavailable).";
		public const string XPATH_PARSE_ERROR = "Cannot read xpath.";
	}
}