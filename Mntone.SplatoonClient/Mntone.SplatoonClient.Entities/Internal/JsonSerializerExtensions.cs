using System;

namespace Mntone.SplatoonClient.Entities.Internal
{
	internal static class JsonSerializerExtensions
	{
		public static readonly Uri DOMAIN_URI = new Uri("https://splatoon.nintendo.net/");
		private const string TIME_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz";

		public static string ToFormattedString(this DateTimeOffset source) => source.ToString(TIME_FORMAT);
		public static DateTimeOffset ToDateTimeOffset(this string source) => DateTime.ParseExact(source, TIME_FORMAT, null);
		
		public static Uri ToAbsoluteUriFromPathAndQuery(this string source) => new Uri(DOMAIN_URI, source);
	}
}