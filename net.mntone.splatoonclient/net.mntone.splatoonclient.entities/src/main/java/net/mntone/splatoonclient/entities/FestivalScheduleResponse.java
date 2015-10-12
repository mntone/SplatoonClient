package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

final class FestivalScheduleResponse implements ScheduleResponse
{
	private final FestivalSchedule[] _schedule;

	FestivalScheduleResponse(final FestivalSchedule[] schedule)
	{
		this._schedule = schedule;
	}

	FestivalScheduleResponse(final JSONObject json) throws Exception
	{
		final boolean festival = json.getBoolean("festival");
		if (!festival)
		{
			throw new IllegalArgumentException();
		}
		this._schedule = JsonUtil.toArray(
			json.getJSONArray("schedule"),
			new JsonUtil.ArrayInstanceFactory<FestivalSchedule>()
			{
				@Override
				public FestivalSchedule createInstance(final JSONObject json) throws Exception
				{
					return new FestivalSchedule(json);
				}

				@Override
				public FestivalSchedule[] createArray(final int size)
				{
					return new FestivalSchedule[size];
				}
			});
	}

	@Override
	public boolean getFestival()
	{
		return true;
	}

	@Override
	public Schedule[] getSchedule()
	{
		return this._schedule;
	}
}