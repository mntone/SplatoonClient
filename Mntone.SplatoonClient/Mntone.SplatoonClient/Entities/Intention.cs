using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	/// <summary>
	/// Intention information
	/// </summary>
	[DataContract]
	public sealed class Intention
	{
		/// <summary>
		/// Intention ID
		/// </summary>
		[DataMember(Name = "id")]
		public string ID { get; private set; }

		/// <summary>
		/// Image uri
		/// </summary>
		[DataMember(Name = "image")]
		public Uri ImageUri { get; private set; }
	}
}