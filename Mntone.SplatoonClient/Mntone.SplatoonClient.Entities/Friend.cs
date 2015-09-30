using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Mntone.SplatoonClient.Entities
{
	/// <summary>
	/// Friend information
	/// </summary>
	[DataContract]
	public sealed class Friend
	{
		internal Friend(string id, bool online, string status, Intention intention, string name, Uri miiImageUri)
		{
			this.ID = id;
			this.IsOnline = online;
			this.Status = status;
			this.Intention = intention;
			this.Name = name;
			this.MiiImageUri = miiImageUri;
		}

		/// <summary>
		/// Friend id
		/// </summary>
		[DataMember(Name = "hashed_id")]
		public string ID { get; private set; }

		/// <summary>
		/// Is online
		/// </summary>
		[DataMember(Name = "online")]
		public bool IsOnline { get; private set; }

		/// <summary>
		/// Status
		/// </summary>
		[DataMember(Name = "status")]
		public string Status { get; private set; }

		/// <summary>
		/// Mode
		/// </summary>
		public GameMode Mode { get; private set; }

		[DataMember(Name = "mode")]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ModeImpl
		{
			get { return this.Mode.ToGameModeString(); }
			set { this.Mode = value.ToGameMode(); }
		}

		/// <summary>
		/// Intention
		/// </summary>
		[DataMember(Name = "intention")]
		public Intention Intention { get; private set; }

		/// <summary>
		/// Name
		/// </summary>
		[DataMember(Name = "mii_name")]
		public string Name { get; private set; }

		/// <summary>
		/// Mii iamge uri
		/// </summary>
		[DataMember(Name = "mii_url")]
		public Uri MiiImageUri { get; private set; }
	}
}