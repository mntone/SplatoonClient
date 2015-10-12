package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

final class NormalScheduleResponse implements ScheduleResponse
{
	private final NormalSchedule[] _schedule;

	NormalScheduleResponse(final NormalSchedule[] schedule)
	{
		this._schedule = schedule;
	}

	NormalScheduleResponse(final JSONObject json) throws Exception
	{
		final boolean festival = json.getBoolean("festival");
		if (festival)
		{
			throw new IllegalArgumentException();
		}
		this._schedule = JsonUtil.toArray(
			json.getJSONArray("schedule"),
			new JsonUtil.ArrayInstanceFactory<NormalSchedule>()
			{
				@Override
				public NormalSchedule createInstance(final JSONObject json) throws Exception
				{
					return new NormalSchedule(json);
				}

				@Override
				public NormalSchedule[] createArray(final int size)
				{
					return new NormalSchedule[size];
				}
			});
	}

	@Override
	public boolean getFestival()
	{
		return false;
	}

	@Override
	public Schedule[] getSchedule()
	{
		return this._schedule;
	}
}