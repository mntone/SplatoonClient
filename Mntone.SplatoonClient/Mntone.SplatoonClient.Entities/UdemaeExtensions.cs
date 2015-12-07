using System;

namespace Mntone.SplatoonClient.Entities
{
	public static class UdemaeExtensions
	{
		public static string AsString(this Udemae udemae)
		{
			switch (udemae)
			{
				case Udemae.CMinus: return "C-";
				case Udemae.C: return "C";
				case Udemae.CPlus: return "C+";
				case Udemae.BMinus: return "B-";
				case Udemae.B: return "B";
				case Udemae.BPlus: return "B+";
				case Udemae.AMinus: return "A-";
				case Udemae.A: return "A";
				case Udemae.APlus: return "A+";
				case Udemae.S: return "S";
				case Udemae.SPlus: return "S+";
			}

			throw new Exception();
		}

		public static Udemae ToUdemae(this string udemaeAsString)
		{
			if (string.IsNullOrEmpty(udemaeAsString)) throw new Exception();

			switch (udemaeAsString)
			{
				case "C-": return Udemae.CMinus;
				case "C": return Udemae.C;
				case "C+": return Udemae.CPlus;
				case "B-": return Udemae.BMinus;
				case "B": return Udemae.B;
				case "B+": return Udemae.BPlus;
				case "A-": return Udemae.AMinus;
				case "A": return Udemae.A;
				case "A+": return Udemae.APlus;
				case "S": return Udemae.S;
				case "S+": return Udemae.SPlus;
			}
			return Udemae.Unknown;
		}
	}
}
