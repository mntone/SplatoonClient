using System;

namespace Mntone.SplatoonClient.Entities
{
	public static class GameModeExtensions
	{
		public static string ToGameModeString(this GameMode mode)
		{
			switch (mode)
			{
				case GameMode.Offline: return "offline";
				case GameMode.Online: return "online";
				case GameMode.Playing: return "playing";
				case GameMode.Regular: return "regular";
				case GameMode.Gachi: return "gachi";
				case GameMode.Tag: return "tag";
				case GameMode.Private: return "privte";
			}

			throw new Exception();
		}

		public static GameMode ToGameMode(this string modeText)
		{
			if (string.IsNullOrEmpty(modeText)) throw new Exception();

			switch (modeText)
			{
				case "offline": return GameMode.Offline;
				case "online": return GameMode.Online;
				case "playing": return GameMode.Playing;
				case "regular": return GameMode.Regular;
				case "gachi": return GameMode.Gachi;
				case "tag": return GameMode.Tag;
				case "private": return GameMode.Private;
			}

			throw new Exception();
		}
	}
}
