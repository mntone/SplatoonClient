package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;
import java.net.URL;

public final class Stage
{
	private final String _name;
	private final URL _imageUri;

	Stage(final String name, final URL imageUri)
	{
		this._name = name;
		this._imageUri = imageUri;
	}

	Stage(final JSONObject json) throws MalformedURLException
	{
		this._name = json.getString("name");
		this._imageUri = new URL(json.getString("asset_path"));
	}

	public String getName()
	{
		return this._name;
	}

	public URL getImageUri()
	{
		return this._imageUri;
	}
}