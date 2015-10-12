package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;
import java.net.URL;

public final class Friend
{
	private final String _id;
	private final boolean _online;
	private final String _status;
	private final GameMode _mode;
	private final Intention _intention;
	private final String _name;
	private final URL _miiImageUri;

	Friend(final String id, final boolean online, final String status, final GameMode mode, final Intention intention, final String name, final URL miiImageUri)
	{
		this._id = id;
		this._online = online;
		this._status = status;
		this._mode = mode;
		this._intention = intention;
		this._name = name;
		this._miiImageUri = miiImageUri;
	}

	Friend(final JSONObject json) throws MalformedURLException
	{
		this._id = json.getString("hashed_id");
		this._online = json.getBoolean("online");
		this._status = json.getString("status");
		this._mode = GameMode.fromText(json.getString("mode"));
		this._intention = new Intention(json.getJSONObject("intention"));
		this._name = json.getString("mii_name");
		this._miiImageUri = new URL(json.getString("mii_url"));
	}

	public String getId()
	{
		return this._id;
	}

	public boolean isOnline()
	{
		return this._online;
	}

	public String getStatus()
	{
		return this._status;
	}

	public GameMode getMode()
	{
		return this._mode;
	}

	public Intention getIntention()
	{
		return this._intention;
	}

	public String getName()
	{
		return this._name;
	}

	public URL getMiiImageUri()
	{
		return this._miiImageUri;
	}
}