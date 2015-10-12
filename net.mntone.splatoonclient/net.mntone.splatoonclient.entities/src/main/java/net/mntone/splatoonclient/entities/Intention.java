package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;
import java.net.URL;

public final class Intention
{
	private final String _id;
	private final URL _uri;

	Intention(final String id, final URL uri)
	{
		this._id = id;
		this._uri = uri;
	}

	Intention(final JSONObject json) throws MalformedURLException
	{
		this._id = json.getString("id");
		this._uri = new URL(json.getString("image"));
	}

	public String getId()
	{
		return this._id;
	}

	public URL getUri()
	{
		return this._uri;
	}
}