using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class RankingResponse
	{
		internal RankingResponse(RankingUser[] regular, RankingUser[] gachi)
		{
			this.Regular = regular;
			this.Gachi = gachi;
		}

		/// <summary>
		/// Regular battle ranking
		/// </summary>
		[DataMember(Name = "regular", IsRequired = true)]
		public RankingUser[] Regular { get; private set; }

		/// <summary>
		/// Ranked battle ranking
		/// </summary>
		[DataMember(Name = "gachi", IsRequired = true)]
		public RankingUser[] Gachi { get; private set; }

		/// <summary>
		/// Splatfest ranking
		/// </summary>
		[DataMember(Name = "festival", IsRequired = true)]
		public FestivalRankingUser[] Festival { get; private set; }
	}
}