using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mntone.SplatoonClient.Internal.XPath
{
	internal interface IXPathRetriveConfig<T>
	{
		Expression<Func<T, IEnumerable<T>>> ChildrenGetter { get; }
		Expression<Func<T, string>> TagNameGetter { get; }
		Expression<Func<T, string>> TextGetter { get; }
		Expression<Func<T, string, string>> AttributeValueGetter { get; }
	}
}