package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.util.Date;

public abstract class ScheduleBase implements Schedule
{
	private final Date _beginDateTime;
	private final Date _endDateTime;

	protected ScheduleBase(final Date beginDateTime, final Date endDateTime)
	{
		this._beginDateTime = beginDateTime;
		this._endDateTime = endDateTime;
	}

	protected ScheduleBase(final JSONObject json)
	{
		this._beginDateTime = JsonUtil.toDateTime(json.getString("datetime_begin"));
		this._endDateTime = JsonUtil.toDateTime(json.getString("datetime_end"));
	}

	@Override
	public Date getBeginDateTime()
	{
		return this._beginDateTime;
	}

	@Override
	public Date getEndDateTime()
	{
		return this._endDateTime;
	}
}