using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class UserProfile
	{
		internal UserProfile()
		{
			this._PaintedRank = new List<PaintedRank>();
		}

		internal UserProfile(string name, Uri miiImageUri, byte rank, Udemae udemae, Uri weaponImageUri, Uri weaponRetinaImageUri, Gear headGear, Gear clothesGear, Gear shoesGear, List<PaintedRank> paintedRank)
		{
			this.Name = name;
			this.MiiImageUri = miiImageUri;
			this.Rank = rank;
			this.Udemae = udemae;
			this.WeaponImageUri = weaponImageUri;
			this.WeaponRetinaImageUri = weaponRetinaImageUri;
			this.HeadGear = headGear;
			this.ClothesGear = clothesGear;
			this.ShoesGear = shoesGear;
			this._PaintedRank = paintedRank;
		}

		/// <summary>
		/// Name
		/// </summary>
		[DataMember(Name = "mii_name", IsRequired = true)]
		public string Name { get; internal set; }

		/// <summary>
		/// Mii image uri
		/// </summary>
		[DataMember(Name = "mii_url", IsRequired = true)]
		public Uri MiiImageUri { get; internal set; }

		/// <summary>
		/// Rank
		/// </summary>
		[DataMember(Name = "rank", IsRequired = true)]
		public byte Rank { get; internal set; }

		/// <summary>
		/// Udemae
		/// </summary>
		public Udemae Udemae { get; private set; }

		[DataMember(Name = "udemae", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		internal string UdemaeAsString
		{
			get { return this.Udemae.AsString(); }
			set { this.Udemae = value.ToUdemae(); }
		}

		/// <summary>
		/// Weapon image uri
		/// </summary>
		public Uri WeaponImageUri { get; internal set; }

		[DataMember(Name = "weapon", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string WeaponImageUriImpl
		{
			get { return this.WeaponImageUri.PathAndQuery; }
			set { this.WeaponImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Weapon retina image uri
		/// </summary>
		public Uri WeaponRetinaImageUri { get; internal set; }

		[DataMember(Name = "weapon2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string WeaponRetinaImageUriImpl
		{
			get { return this.WeaponRetinaImageUri.PathAndQuery; }
			set { this.WeaponRetinaImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Head gear
		/// </summary>
		[DataMember(Name = "head_gear", IsRequired = true)]
		public Gear HeadGear { get; internal set; }

		/// <summary>
		/// Clothes gear
		/// </summary>
		[DataMember(Name = "clothes_gear", IsRequired = true)]
		public Gear ClothesGear { get; internal set; }

		/// <summary>
		/// Shoes gear
		/// </summary>
		[DataMember(Name = "shoes_gear", IsRequired = true)]
		public Gear ShoesGear { get; internal set; }

		/// <summary>
		/// Painted rank
		/// </summary>
		public IReadOnlyList<PaintedRank> PaintedRank => this._PaintedRank;
		internal List<PaintedRank> _PaintedRank = null;
	}
}