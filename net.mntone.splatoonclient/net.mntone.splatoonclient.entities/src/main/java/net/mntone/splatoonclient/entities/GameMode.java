package net.mntone.splatoonclient.entities;

public enum GameMode
{
	Offline,
	Online,
	Playing,
	Regular,
	Gachi,
	Tag,
	Private,
	Fes;

	public String getGameModeText() throws Exception
	{
		switch (this)
		{
		case Offline:
			return "offline";
		case Online:
			return "online";
		case Playing:
			return "playing";
		case Regular:
			return "regular";
		case Gachi:
			return "gachi";
		case Tag:
			return "tag";
		case Private:
			return "private";
		case Fes:
			return "fes";
		}

		throw new Exception();
	}

	public static GameMode fromText(String text) throws IllegalArgumentException
	{
		if ("offline".equals(text))
		{
			return GameMode.Offline;
		}
		if ("online".equals(text))
		{
			return GameMode.Online;
		}
		if ("playing".equals(text))
		{
			return GameMode.Playing;
		}
		if ("regular".equals(text))
		{
			return GameMode.Regular;
		}
		if ("gachi".equals(text))
		{
			return GameMode.Gachi;
		}
		if ("tag".equals(text))
		{
			return GameMode.Tag;
		}
		if ("private".equals(text))
		{
			return GameMode.Private;
		}
		if ("fes".equals(text))
		{
			return GameMode.Fes;
		}

		throw new IllegalArgumentException();
	}
}