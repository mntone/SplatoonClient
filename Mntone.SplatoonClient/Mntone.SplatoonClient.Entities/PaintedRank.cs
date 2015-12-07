using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class PaintedRank
	{
		internal PaintedRank(Uri imageUri, Uri retinaImageUri, uint paintedPoint)
		{
			this.ImageUri = imageUri;
			this.RetinaImageUri = retinaImageUri;
			this.PaintedPoint = paintedPoint;
		}

		/// <summary>
		/// Weapon image uri
		/// </summary>
		public Uri ImageUri { get; private set; }

		[DataMember(Name = "image", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ImageUriImpl
		{
			get { return this.ImageUri.PathAndQuery; }
			set { this.ImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Weapon retina image uri
		/// </summary>
		public Uri RetinaImageUri { get; private set; }

		[DataMember(Name = "image2x", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string RetinaImageUriImpl
		{
			get { return this.RetinaImageUri.PathAndQuery; }
			set { this.RetinaImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}

		/// <summary>
		/// Painted point
		/// </summary>
		public uint PaintedPoint { get; private set; }
	}
}