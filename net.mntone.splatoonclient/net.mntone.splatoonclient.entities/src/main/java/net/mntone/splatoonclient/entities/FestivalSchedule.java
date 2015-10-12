package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.util.Date;

final class FestivalSchedule extends ScheduleBase
{
	private final FestivalStages _stages;
	private final String _teamAlphaName;
	private final String _teamBravoName;

	FestivalSchedule(final Date beginDateTime, final Date endDateTime, final FestivalStages stages, final String teamAlphaName, final String teamBravoName)
	{
		super(beginDateTime, endDateTime);
		this._stages = stages;
		this._teamAlphaName = teamAlphaName;
		this._teamBravoName = teamBravoName;
	}

	FestivalSchedule(final JSONObject json) throws Exception
	{
		super(json);
		this._stages = new FestivalStages(json.getJSONObject("stages"));
		this._teamAlphaName = json.getString("team_alpha_name");
		this._teamBravoName = json.getString("team_bravo_name");
	}

	@Override
	public String getGachiRule()
	{
		return null;
	}

	@Override
	public Stages getStages()
	{
		return this._stages;
	}

	@Override
	public String getTeamAlphaName()
	{
		return this._teamAlphaName;
	}

	@Override
	public String getTeamBravoName()
	{
		return this._teamBravoName;
	}
}