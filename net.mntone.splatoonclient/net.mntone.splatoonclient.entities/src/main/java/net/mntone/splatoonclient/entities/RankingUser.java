package net.mntone.splatoonclient.entities;

import org.json.JSONObject;

import java.net.MalformedURLException;
import java.net.URL;

public final class RankingUser
{
	private final String _id;
	private final int _rank;
	private final int _score;
	private final String _name;
	private final URL _miiImageUri;
	private final URL _weaponImageUri;
	private final URL _weaponRetinaImageUri;
	private final URL _headImageUri;
	private final URL _headRetinaImageUri;
	private final URL _clothesImageUri;
	private final URL _clothesRetinaImageUri;
	private final URL _shoesImageUri;
	private final URL _shoesRetinaImageUri;

	RankingUser(final String id, final int rank, final int score, final String name, final URL miiImageUri, final URL weaponImageUri, final URL weaponRetinaImageUri, final URL headImageUri, final URL headRetinaImageUri, final URL clothesImageUri, final URL clothesRetinaImageUri, final URL shoesImageUri, final URL shoesRetinaImageUri)
	{
		this._id = id;
		this._rank = rank;
		this._score = score;
		this._name = name;
		this._miiImageUri = miiImageUri;
		this._weaponImageUri = weaponImageUri;
		this._weaponRetinaImageUri = weaponRetinaImageUri;
		this._headImageUri = headImageUri;
		this._headRetinaImageUri = headRetinaImageUri;
		this._clothesImageUri = clothesImageUri;
		this._clothesRetinaImageUri = clothesRetinaImageUri;
		this._shoesImageUri = shoesImageUri;
		this._shoesRetinaImageUri = shoesRetinaImageUri;
	}

	RankingUser(final JSONObject json) throws MalformedURLException
	{
		this._id = json.getString("hashed_id");
		this._rank = JsonUtil.convertJsonIntArrayToInt(json.getJSONArray("rank"));
		this._score = JsonUtil.convertJsonIntArrayToInt(json.getJSONArray("score"));
		this._name = json.getString("mii_name");
		this._miiImageUri = new URL(json.getString("mii_url"));
		this._weaponImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("weapon"), "weapon", false);
		this._weaponRetinaImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("weapon2x"), "weapon", true);
		this._headImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("head"), "head", false);
		this._headRetinaImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("head2x"), "head", true);
		this._clothesImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("clothes"), "clothes", false);
		this._clothesRetinaImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("clothes2x"), "clothes", true);
		this._shoesImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("shoes"), "shoes", false);
		this._shoesRetinaImageUri = JsonUtil.toWeaponOrGearImageUri(json.getString("shoes2x"), "shoes", true);
	}

	public String getId()
	{
		return this._id;
	}

	public int getRank()
	{
		return this._rank;
	}

	public int getScore()
	{
		return this._score;
	}

	public String getName()
	{
		return this._name;
	}

	public URL getMiiImageUri()
	{
		return this._miiImageUri;
	}

	public URL getWeaponImageUri()
	{
		return this._weaponImageUri;
	}

	public URL getWeaponRetinaImageUri()
	{
		return this._weaponRetinaImageUri;
	}

	public URL getHeadImageUri()
	{
		return this._headImageUri;
	}

	public URL getHeadRetinaImageUri()
	{
		return this._headRetinaImageUri;
	}

	public URL getClothesImageUri()
	{
		return this._clothesImageUri;
	}

	public URL getClothesRetinaImageUri()
	{
		return this._clothesRetinaImageUri;
	}

	public URL getShoesImageUri()
	{
		return this._shoesImageUri;
	}

	public URL getShoesRetinaImageUri()
	{
		return this._shoesRetinaImageUri;
	}
}