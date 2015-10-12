package net.mntone.splatoonclient.entities;

import org.json.JSONArray;
import org.json.JSONObject;

public class SplatoonEntitiesFactory
{
	protected SplatoonEntitiesFactory()
	{
		if (!this.getClass().getName().startsWith("net.mntone.splatoonclient."))
		{
			throw new RuntimeException();
		}
	}

	public Friend[] createFriends(final String jsonText) throws Exception
	{
		final JSONArray root = JsonUtil.getJsonArray(jsonText);
		return JsonUtil.toArray(root, new JsonUtil.ArrayInstanceFactory<Friend>()
		{
			@Override
			public Friend createInstance(final JSONObject json) throws Exception
			{
				return new Friend(json);
			}

			@Override
			public Friend[] createArray(final int size)
			{
				return new Friend[size];
			}
		});
	}

	public ScheduleResponse createScheduleResponse(final String jsonText) throws Exception
	{
		final JSONObject root = JsonUtil.getJsonObject(jsonText);
		if (jsonText.contains("\"festival\":true"))
		{
			return new FestivalScheduleResponse(root);
		}
		return new NormalScheduleResponse(root);
	}

	public RankingResponse createRankingResponse(final String jsonText) throws Exception
	{
		final JSONObject root = JsonUtil.getJsonObject(jsonText);
		return new RankingResponse(root);
	}
}