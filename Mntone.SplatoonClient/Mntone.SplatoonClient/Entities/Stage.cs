using System;

namespace Mntone.SplatoonClient.Entities
{
	/// <summary>
	/// Stage information
	/// </summary>
	public sealed class Stage
	{
		internal Stage(string name, Uri imageUri, Uri retinaImageUri)
		{
			this.Name = name;
			this.ImageUri = imageUri;
			this.RetinaImageUri = retinaImageUri;
		}

		/// <summary>
		/// Stage name (ja-JP)
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Stage image uri
		/// </summary>
		public Uri ImageUri { get; }

		/// <summary>
		/// Stage retina (2x) image uri
		/// </summary>
		public Uri RetinaImageUri { get; }
	}
}