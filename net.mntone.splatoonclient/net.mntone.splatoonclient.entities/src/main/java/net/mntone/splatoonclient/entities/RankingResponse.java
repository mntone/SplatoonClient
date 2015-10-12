package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;

public final class RankingResponse
{
	private final RankingUser[] _regular;
	private final RankingUser[] _gachi;

	RankingResponse(final RankingUser[] regular, final RankingUser[] gachi)
	{
		this._regular = regular;
		this._gachi = gachi;
	}

	RankingResponse(final JSONObject json) throws Exception
	{
		this._regular = JsonUtil.toArray(json.getJSONArray("regular"), new JsonUtil.ArrayInstanceFactory<RankingUser>()
		{
			@Override
			public RankingUser createInstance(final JSONObject json) throws MalformedURLException
			{
				return new RankingUser(json);
			}

			@Override
			public RankingUser[] createArray(final int size)
			{
				return new RankingUser[size];
			}
		});
		this._gachi = JsonUtil.toArray(json.getJSONArray("gachi"), new JsonUtil.ArrayInstanceFactory<RankingUser>()
		{
			@Override
			public RankingUser createInstance(final JSONObject json) throws MalformedURLException
			{
				return new RankingUser(json);
			}

			@Override
			public RankingUser[] createArray(final int size)
			{
				return new RankingUser[size];
			}
		});
	}

	public RankingUser[] getRegular()
	{
		return this._regular;
	}

	public RankingUser[] getGachi()
	{
		return this._gachi;
	}
}