package net.mntone.splatoonclient.entities;

import java.util.Date;

public interface Schedule
{
	Date getBeginDateTime();

	Date getEndDateTime();

	String getGachiRule();

	Stages getStages();

	String getTeamAlphaName();

	String getTeamBravoName();
}