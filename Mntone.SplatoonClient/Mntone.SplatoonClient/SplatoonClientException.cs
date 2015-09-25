using System;

namespace Mntone.SplatoonClient
{
	public sealed class SplatoonClientException : Exception
	{
		public SplatoonClientException(string message)
			: base(message)
		{ }
	}
}