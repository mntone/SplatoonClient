using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class Gear
	{
		internal Gear() { }

		internal Gear(Uri imageUri, Uri retinaImageUri, Uri mainSvgUri, Uri sub1SvgUri, Uri sub2SvgUri, Uri sub3SvgUri)
		{
			this.ImageUri = imageUri;
			this.RetinaImageUri = retinaImageUri;
			this.GearPowerMainSvgUri = mainSvgUri;
			this.GearPowerSub1SvgUri = sub1SvgUri;
			this.GearPowerSub2SvgUri = sub2SvgUri;
			this.GearPowerSub3SvgUri = sub3SvgUri;
		}

		/// <summary>
		/// Gear image uri
		/// </summary>
		public Uri ImageUri { get; internal set; }

		[DataMember(Name = "image", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ImageUriImpl
		{
			get { return this.ImageUri.PathAndQuery; }
			set { this.ImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Gear retina image uri
		/// </summary>
		public Uri RetinaImageUri { get; internal set; }

		[DataMember(Name = "image2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string RetinaImageUriImpl
		{
			get { return this.RetinaImageUri.PathAndQuery; }
			set { this.RetinaImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Gear power main svg uri
		/// </summary>
		public Uri GearPowerMainSvgUri { get; internal set; }

		[DataMember(Name = "gear_power_main", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string GearPowerMainSvgUriImpl
		{
			get { return this.GearPowerMainSvgUri.PathAndQuery; }
			set { this.GearPowerMainSvgUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Gear power sub[0] svg uri
		/// </summary>
		public Uri GearPowerSub1SvgUri { get; internal set; }

		[DataMember(Name = "gear_power_sub1", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string GearPowerSub1SvgUriImpl
		{
			get { return this.GearPowerSub1SvgUri.PathAndQuery; }
			set { this.GearPowerSub1SvgUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Gear power sub[1] svg uri
		/// </summary>
		public Uri GearPowerSub2SvgUri { get; internal set; }

		[DataMember(Name = "gear_power_sub2", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string GearPowerSub2SvgUriImpl
		{
			get { return this.GearPowerSub2SvgUri.PathAndQuery; }
			set { this.GearPowerSub2SvgUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Gear power sub[2] svg uri
		/// </summary>
		public Uri GearPowerSub3SvgUri { get; internal set; }

		[DataMember(Name = "gear_power_sub3", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string GearPowerSub3SvgUriImpl
		{
			get { return this.GearPowerSub3SvgUri.PathAndQuery; }
			set { this.GearPowerSub3SvgUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}
	}
}