using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	[DataContract]
	public sealed class Stages
	{
		private Stages() { }

		internal Stages(Stage[] regular, Stage[] gachi)
		{
			this.Regular = regular;
			this.Gachi = gachi;
		}

		/// <summary>
		/// Regular battle stages
		/// </summary>
		[DataMember(Name = "regular", IsRequired = true)]
		public Stage[] Regular { get; private set; }

		/// <summary>
		/// Gachi battle stages
		/// </summary>
		[DataMember(Name = "gachi", IsRequired = true)]
		public Stage[] Gachi { get; private set; }
	}
}