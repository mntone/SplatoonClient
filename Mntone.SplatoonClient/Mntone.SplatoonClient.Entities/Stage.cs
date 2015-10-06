using Mntone.SplatoonClient.Entities.Internal;
using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	/// <summary>
	/// Stage information
	/// </summary>
	[DataContract]
	[System.Diagnostics.DebuggerDisplay("Name = {this.Name}")]
	public sealed class Stage
	{
		private Stage() { }

		internal Stage(string name, Uri imageUri)
		{
			this.Name = name;
			this.ImageUri = imageUri;
		}

		/// <summary>
		/// Stage name
		/// </summary>
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; private set; }

		/// <summary>
		/// Stage image uri
		/// </summary>
		public Uri ImageUri { get; private set; }

		[DataMember(Name = "asset_path", IsRequired = true)]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string ImageUriImpl
		{
			get { return this.ImageUri.PathAndQuery; }
			set { this.ImageUri = value.ToAbsoluteUriFromPathAndQuery(); }
		}
	}
}