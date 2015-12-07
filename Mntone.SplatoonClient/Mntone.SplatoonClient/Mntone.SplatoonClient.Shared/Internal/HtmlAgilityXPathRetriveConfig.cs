using HtmlAgilityPack;
using Mntone.XPath;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mntone.SplatoonClient.Shared.Internal
{
	internal sealed class HtmlAgilityXPathRetriveConfig : IXPathRetriveConfig<HtmlNode>
	{
		public static HtmlAgilityXPathRetriveConfig Instance { get { return _Instance ?? (_Instance = new HtmlAgilityXPathRetriveConfig()); } }
		private static HtmlAgilityXPathRetriveConfig _Instance = null;

		private HtmlAgilityXPathRetriveConfig() { }

		public Expression<Func<HtmlNode, IEnumerable<HtmlNode>>> ChildrenGetter => node => node.ChildNodes;

		public Expression<Func<HtmlNode, string>> TagNameGetter => node => node.Name;
		public Expression<Func<HtmlNode, string>> TextGetter => node => node.InnerText;
		public Expression<Func<HtmlNode, string, string>> AttributeValueGetter => (node, name) => node.GetAttributeValue(name, string.Empty);
	}
}
