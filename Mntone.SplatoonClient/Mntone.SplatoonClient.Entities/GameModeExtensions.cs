using System;

namespace Mntone.SplatoonClient.Entities
{
	public static class GameModeExtensions
	{
		public static string AsString(this GameMode mode)
		{
			switch (mode)
			{
				case GameMode.Offline: return "offline";
				case GameMode.Online: return "online";
				case GameMode.Playing: return "playing";
				case GameMode.Regular: return "regular";
				case GameMode.Gachi: return "gachi";
				case GameMode.Tag: return "tag";
				case GameMode.Private: return "private";
				case GameMode.Fes: return "fes";
			}

			throw new Exception();
		}

		public static GameMode ToGameMode(this string modeAsString)
		{
			if (string.IsNullOrEmpty(modeAsString)) throw new Exception();

			switch (modeAsString)
			{
				case "offline": return GameMode.Offline;
				case "online": return GameMode.Online;
				case "playing": return GameMode.Playing;
				case "regular": return GameMode.Regular;
				case "gachi": return GameMode.Gachi;
				case "tag": return GameMode.Tag;
				case "private": return GameMode.Private;
				case "fes": return GameMode.Fes;
			}

			throw new Exception();
		}
	}
}
