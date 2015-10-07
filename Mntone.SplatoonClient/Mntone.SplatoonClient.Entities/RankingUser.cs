using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	[System.Diagnostics.DebuggerDisplay("{this.Rank}: {this.Name} ({this.Score}) ")]
	public sealed class RankingUser
	{
		internal RankingUser(string id, uint rank, uint score, string name, Uri miiImageUri,
			Uri weaponImageUri, Uri weaponRetinaImageUri,
			Uri headImageUri, Uri headRetinaImageUri,
			Uri clothesImageUri, Uri clothesRetinaImageUri,
			Uri shoesImageUri, Uri shoesRetinaImageUri)
		{
			this.ID = id;
			this.Rank = rank;
			this.Score = score;
			this.Name = name;
			this.MiiImageUri = miiImageUri;
			this.WeaponImageUri = weaponImageUri;
			this.WeaponRetinaImageUri = weaponRetinaImageUri;
			this.HeadImageUri = headImageUri;
			this.HeadRetinaImageUri = headRetinaImageUri;
			this.ClothesImageUri = clothesImageUri;
			this.ClothesRetinaImageUri = clothesRetinaImageUri;
			this.ShoesImageUri = shoesImageUri;
			this.ShoesRetinaImageUri = shoesRetinaImageUri;
		}

		/// <summary>
		/// User id
		/// </summary>
		[DataMember(Name = "hashed_id")]
		public string ID { get; private set; }

		/// <summary>
		/// Rank
		/// </summary>
		public uint Rank { get; private set; }

		[DataMember(Name = "rank", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private uint[] RankImpl
		{
			get { return this.Rank.ToUInt32Array(); }
			set { this.Rank = value.ToUInt32(); }
		}

		/// <summary>
		/// Score
		/// </summary>
		public uint Score { get; private set; }

		[DataMember(Name = "score", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private uint[] ScoreImpl
		{
			get { return this.Score.ToUInt32Array(); }
			set { this.Score = value.ToUInt32(); }
		}

		/// <summary>
		/// Name
		/// </summary>
		[DataMember(Name = "mii_name", IsRequired = true)]
		public string Name { get; private set; }

		/// <summary>
		/// Mii iamge uri
		/// </summary>
		[DataMember(Name = "mii_url", IsRequired = true)]
		public Uri MiiImageUri { get; private set; }

		/// <summary>
		/// Weapon image uri
		/// </summary>
		public Uri WeaponImageUri { get; private set; }

		[DataMember(Name = "weapon", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string WeaponImageUriImpl
		{
			get { return this.WeaponImageUri.ToFilename(); }
			set { this.WeaponImageUri = value.ToWeaponOrGearImageUri("weapon", false); }
		}

		/// <summary>
		/// Weapon retina image uri
		/// </summary>
		public Uri WeaponRetinaImageUri { get; private set; }

		[DataMember(Name = "weapon2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string WeaponRetinaImageUriImpl
		{
			get { return this.WeaponRetinaImageUri.ToFilename(); }
			set { this.WeaponRetinaImageUri = value.ToWeaponOrGearImageUri("weapon", true); }
		}

		/// <summary>
		/// Head image uri
		/// </summary>
		public Uri HeadImageUri { get; private set; }

		[DataMember(Name = "head", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string HeadImageUriImpl
		{
			get { return this.HeadImageUri.ToFilename(); }
			set { this.HeadImageUri = value.ToWeaponOrGearImageUri("head", false); }
		}

		/// <summary>
		/// Weapon retina image uri
		/// </summary>
		public Uri HeadRetinaImageUri { get; private set; }

		[DataMember(Name = "head2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string HeadRetinaImageUriImpl
		{
			get { return this.HeadRetinaImageUri.ToFilename(); }
			set { this.HeadRetinaImageUri = value.ToWeaponOrGearImageUri("head", true); }
		}

		/// <summary>
		/// Clothes image uri
		/// </summary>
		public Uri ClothesImageUri { get; private set; }

		[DataMember(Name = "clothes", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ClothesImageUriImpl
		{
			get { return this.ClothesImageUri.ToFilename(); }
			set { this.ClothesImageUri = value.ToWeaponOrGearImageUri("clothes", false); }
		}

		/// <summary>
		/// Weapon retina image uri
		/// </summary>
		public Uri ClothesRetinaImageUri { get; private set; }

		[DataMember(Name = "clothes2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ClothesRetinaImageUriImpl
		{
			get { return this.ClothesRetinaImageUri.ToFilename(); }
			set { this.ClothesRetinaImageUri = value.ToWeaponOrGearImageUri("clothes", true); }
		}

		/// <summary>
		/// Shoes image uri
		/// </summary>
		public Uri ShoesImageUri { get; private set; }

		[DataMember(Name = "shoes", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ShoesImageUriImpl
		{
			get { return this.ShoesImageUri.ToFilename(); }
			set { this.ShoesImageUri = value.ToWeaponOrGearImageUri("shoes", false); }
		}

		/// <summary>
		/// Weapon retina image uri
		/// </summary>
		public Uri ShoesRetinaImageUri { get; private set; }

		[DataMember(Name = "shoes2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ShoesRetinaImageUriImpl
		{
			get { return this.ShoesRetinaImageUri.ToFilename(); }
			set { this.ShoesRetinaImageUri = value.ToWeaponOrGearImageUri("shoes", true); }
		}
	}
}
