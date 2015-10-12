package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.util.Date;

final class NormalSchedule extends ScheduleBase
{
	private final String _gachiRule;
	private final NormalStages _stages;

	NormalSchedule(final Date beginDateTime, final Date endDateTime, final String gachiRule, final NormalStages stages)
	{
		super(beginDateTime, endDateTime);
		this._gachiRule = gachiRule;
		this._stages = stages;
	}

	NormalSchedule(final JSONObject json) throws Exception
	{
		super(json);
		this._gachiRule = json.getString("gachi_rule");
		this._stages = new NormalStages(json.getJSONObject("stages"));
	}

	@Override
	public String getGachiRule()
	{
		return this._gachiRule;
	}

	@Override
	public Stages getStages()
	{
		return this._stages;
	}

	@Override
	public String getTeamAlphaName()
	{
		return null;
	}

	@Override
	public String getTeamBravoName()
	{
		return null;
	}
}