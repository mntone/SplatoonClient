namespace Mntone.SplatoonClient.Entities
{
	public sealed class StagesResponse
	{
		internal StagesResponse(StageInformation[] stageInformation)
		{
			this.StageInformation = stageInformation;
		}

		/// <summary>
		/// Regular battle stages
		/// </summary>
		public StageInformation[] StageInformation { get; }
	}
}