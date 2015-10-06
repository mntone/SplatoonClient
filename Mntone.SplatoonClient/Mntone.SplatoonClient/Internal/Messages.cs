namespace Mntone.SplatoonClient.Internal
{
	internal sealed class Messages
	{
		public const string DISPOSED_OBJECT = "You use disposed object. You must not use it.";
		public const string XPATH_PARSE_ERROR = "Cannot read xpath.";
		public const string UNAUTHORIZED = "Response status code does not indicate success: 401 (Unauthorized).";
		public const string SERVICE_UNAVAILBLE = "Response status code does not indicate success: 503 (Service Unavailable).";
	}
}