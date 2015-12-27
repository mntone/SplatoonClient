using System;

namespace Mntone.SplatoonClient
{
	public sealed class SplatoonClientException : Exception
	{
		public SplatoonClientException(string message)
			: base(message)
		{ }

		public SplatoonClientException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}