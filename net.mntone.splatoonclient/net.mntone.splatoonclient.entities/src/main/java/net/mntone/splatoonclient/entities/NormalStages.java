package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;

final class NormalStages implements Stages
{
	private final Stage[] _regular;
	private final Stage[] _gachi;

	NormalStages(final Stage[] regular, final Stage[] gachi)
	{
		this._regular = regular;
		this._gachi = gachi;
	}

	NormalStages(final JSONObject json) throws Exception
	{
		this._regular = JsonUtil.toArray(json.getJSONArray("regular"), new JsonUtil.ArrayInstanceFactory<Stage>()
		{
			@Override
			public Stage createInstance(final JSONObject json) throws MalformedURLException
			{
				return new Stage(json);
			}

			@Override
			public Stage[] createArray(final int size)
			{
				return new Stage[size];
			}
		});
		this._gachi = JsonUtil.toArray(json.getJSONArray("gachi"), new JsonUtil.ArrayInstanceFactory<Stage>()
		{
			@Override
			public Stage createInstance(final JSONObject json) throws MalformedURLException
			{
				return new Stage(json);
			}

			@Override
			public Stage[] createArray(final int size)
			{
				return new Stage[size];
			}
		});
	}

	@Override
	public Stage[] getRegular()
	{
		return this._regular;
	}

	@Override
	public Stage[] getGachi()
	{
		return this._gachi;
	}
}