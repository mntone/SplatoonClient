using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	public interface IStages
	{
		Stage[] Gachi { get; }
		Stage[] Regular { get; }
	}

	[DataContract]
	internal sealed class NormalStages : IStages
	{
		internal NormalStages(Stage[] regular, Stage[] gachi)
		{
			this.Regular = regular;
			this.Gachi = gachi;
		}

		/// <summary>
		/// Regular battle stages
		/// </summary>
		[DataMember(Name = "regular", IsRequired = true)]
		public Stage[] Regular { get; internal set; }

		/// <summary>
		/// Gachi battle stages
		/// </summary>
		[DataMember(Name = "gachi", IsRequired = true)]
		public Stage[] Gachi { get; private set; }
	}

	internal sealed class FestivalStages : IStages
	{
		internal FestivalStages(Stage[] fest)
		{
			this.Regular = fest;
		}

		/// <summary>
		/// Regular battle stages
		/// </summary>
		public Stage[] Regular { get; internal set; }

		/// <summary>
		/// Gachi battle stages
		/// </summary>
		public Stage[] Gachi => null;
	}
}