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
		[DataMember(Name = "hashed_id", IsRequired = true)]
		public string ID { get; private set; }

		/// <summary>
		/// Is online
		/// </summary>
		[DataMember(Name = "online", IsRequired = true)]
		public bool IsOnline { get; private set; }

		/// <summary>
		/// Status
		/// </summary>
		[DataMember(Name = "status", IsRequired = true)]
		public string Status { get; private set; }

		/// <summary>
		/// Mode
		/// </summary>
		public GameMode Mode { get; private set; }

		[DataMember(Name = "mode", IsRequired = true)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ModeAsString
		{
			get { return this.Mode.AsString(); }
			set { this.Mode = value.ToGameMode(); }
		}

		/// <summary>
		/// Intention
		/// </summary>
		[DataMember(Name = "intention", IsRequired = true)]
		public Intention Intention { get; private set; }

		/// <summary>
		/// Name
		/// </summary>
		[DataMember(Name = "mii_name", IsRequired = true)]
		public string Name { get; private set; }

		/// <summary>
		/// Mii image uri
		/// </summary>
		[DataMember(Name = "mii_url", IsRequired = true)]
		public Uri MiiImageUri { get; private set; }
	}
}