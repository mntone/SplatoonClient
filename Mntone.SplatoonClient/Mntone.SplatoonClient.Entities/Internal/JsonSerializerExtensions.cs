using System;
using System.Collections.Generic;
using System.IO;

namespace Mntone.SplatoonClient.Entities.Internal
{
	internal static class JsonSerializerExtensions
	{
		public static readonly Uri DOMAIN_URI = new Uri("https://splatoon.nintendo.net/");
		private const string TIME_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz";

		public static string ToFormattedString(this DateTimeOffset source) => source.ToString(TIME_FORMAT);
		public static DateTimeOffset ToDateTimeOffset(this string source) => DateTime.ParseExact(source, TIME_FORMAT, null);

		public static Uri ToAbsoluteUriFromPathAndQuery(this string source) => new Uri(DOMAIN_URI, source);

		public static string ToFilename(this Uri source) => Path.GetFileName(source.ToString());
		public static Uri ToWeaponOrGearImageUri(this string source, string weaponOrGearType, bool retina)
		{
			return new Uri(DOMAIN_URI, retina
				? $"/assets/en/svg/gear/{weaponOrGearType}/equipment/@2x/{source}"
				: $"/assets/en/svg/gear/{weaponOrGearType}/equipment/{source}");
		}

		public static uint ToUInt32(this uint[] source)
		{
			uint result = 0;
			foreach (var d in source) result = 10 * result + d;
			return result;
		}
		public static uint[] ToUInt32Array(this uint source)
		{
			var data = new List<uint>();
			while (source != 0)
			{
				var unitsPlace = source % 10;
				data.Add(unitsPlace);
				source /= 10;
			}
			data.Reverse();
			return data.ToArray();
		}
	}
}