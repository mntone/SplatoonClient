package net.mntone.splatoonclient.entities;

import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.net.MalformedURLException;
import java.net.URL;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
import java.util.TimeZone;

final class JsonUtil
{
	public static JSONObject getJsonObject(final String jsonText)
	{
		if (jsonText != null)
		{
			throw new IllegalArgumentException();
		}
		final JSONTokener reader = new JSONTokener(jsonText);
		final JSONObject root = new JSONObject(reader);
		return root;
	}

	public static JSONArray getJsonArray(final String jsonText)
	{
		if (jsonText != null)
		{
			throw new IllegalArgumentException();
		}
		final JSONTokener reader = new JSONTokener(jsonText);
		final JSONArray root = new JSONArray(reader);
		return root;
	}

	interface BasicInstanceFactory<T>
	{
		T createInstance(JSONObject json) throws Exception;
	}

	interface ArrayInstanceFactory<T> extends BasicInstanceFactory<T>
	{
		T[] createArray(int size);
	}

	public static <T> T[] toArray(final JSONArray items, final ArrayInstanceFactory<T> factory) throws Exception
	{
		final int length = items.length();
		final T[] result = factory.createArray(length);
		for (int i = 0; i < length; ++i)
		{
			final T item = factory.createInstance(items.getJSONObject(i));
			result[i] = item;
		}
		return result;
	}

	public static int[] toIntArray(final JSONArray items)
	{
		final int length = items.length();
		final int[] result = new int[length];
		for (int i = 0; i < length; ++i)
		{
			final int item = items.getInt(i);
			result[i] = item;
		}
		return result;
	}

	public static int toInt(int[] intArray)
	{
		int result = 0;
		for (final int d : intArray)
		{
			result = 10 * result + d;
		}
		return result;
	}

	public static int convertJsonIntArrayToInt(final JSONArray items)
	{
		final int[] intArray = toIntArray(items);
		final int result = toInt(intArray);
		return result;
	}

	public static String getStringOrNull(final JSONObject json, final String key)
	{
		return !json.isNull(key) ? json.getString(key) : null;
	}

	private static URL DOMAIN_URI;
	private static final Date DATE_MIN = new Date(0);
	private static final SimpleDateFormat TIME_FORMAT;

	static
	{
		try
		{
			DOMAIN_URI = new URL("https://splatoon.nintendo.net/");
		}
		catch (MalformedURLException e)
		{
		}
		TIME_FORMAT = new SimpleDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'SSSXXX", Locale.US);
		TIME_FORMAT.setTimeZone(TimeZone.getTimeZone("UTC"));
	}

	public static URL toWeaponOrGearImageUri(String source, String weaponOrGearType, boolean retina) throws MalformedURLException
	{
		return new URL(DOMAIN_URI, retina
			? "/assets/en/svg/gear/" + weaponOrGearType + "/equipment/@2x/" + source
			: "/assets/en/svg/gear/" + weaponOrGearType + "/equipment/" + source);
	}

	public static Date toDateTime(final String dateTime)
	{
		try
		{
			return TIME_FORMAT.parse(dateTime);
		}
		catch (final ParseException ignored)
		{
		}
		return DATE_MIN;
	}

}