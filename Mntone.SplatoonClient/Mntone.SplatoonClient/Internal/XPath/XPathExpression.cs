using System;
using System.Collections.Generic;

namespace Mntone.SplatoonClient.Internal.XPath
{
	internal static class XPathExpression
	{
		public static Func<IEnumerable<TIn>, IEnumerable<TOut>> Compile<TIn, TOut>(string xpath, IXPathRetriveConfig<TIn> config)
		{
			var parser = new XPathParser(xpath);
			var builder = parser.Parse();
			return builder.Build<TIn, TOut>(config);
		}
	}
}