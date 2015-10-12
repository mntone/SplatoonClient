package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;

final class FestivalStages implements Stages
{
	private final Stage[] _regular;

	FestivalStages(final Stage[] regular)
	{
		this._regular = regular;
	}

	FestivalStages(final JSONObject json) throws Exception
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
	}

	@Override
	public Stage[] getRegular()
	{
		return new Stage[0];
	}

	@Override
	public Stage[] getGachi()
	{
		return null;
	}
}