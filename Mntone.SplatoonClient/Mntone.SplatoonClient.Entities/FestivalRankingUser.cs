using System;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	[System.Diagnostics.DebuggerDisplay("{this.Rank}: {this.Name} ({this.Score}) ")]
	public sealed class FestivalRankingUser : RankingUser
	{
		internal FestivalRankingUser(string id, uint rank, uint score, bool top100, string name, Uri miiImageUri,
			Uri weaponImageUri, Uri weaponRetinaImageUri,
			Uri headImageUri, Uri headRetinaImageUri,
			Uri clothesImageUri, Uri clothesRetinaImageUri,
			Uri shoesImageUri, Uri shoesRetinaImageUri)
			: base(
				  id, rank, score, name, miiImageUri,
				  weaponImageUri, weaponRetinaImageUri, headImageUri, headRetinaImageUri, clothesImageUri, clothesRetinaImageUri, shoesImageUri, shoesRetinaImageUri)
		{
			this.Top100 = top100;
		}

		/// <summary>
		/// Top 100
		/// </summary>
		[DataMember(Name = "top100")]
		public bool Top100 { get; private set; }
	}
}
