using System.Diagnostics;
using System.Linq.Expressions;

namespace Mntone.SplatoonClient.Internal.XPath
{
	internal abstract class XPathCondition
	{
		public abstract Expression Build<T>(ParameterExpression parameter, IXPathRetriveConfig<T> config);
	}

	[DebuggerDisplay("TagName = {this.TagName}")]
	internal sealed class TagNameXPathCondition : XPathCondition
	{
		public string TagName { get; }

		public TagNameXPathCondition(string tagName)
		{
			this.TagName = tagName;
		}

		public override Expression Build<T>(ParameterExpression parameter, IXPathRetriveConfig<T> config)
		{
			return Expression.Equal(
				Expression.Invoke(config.TagNameGetter, parameter),
				Expression.Constant(this.TagName, typeof(string)));
		}
	}

	[DebuggerDisplay("Name = {this.Name}, Value = {this.Value}")]
	internal sealed class AttributeXPathCondition : XPathCondition
	{
		public string Name { get; }
		public string Value { get; }

		public AttributeXPathCondition(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		public override Expression Build<T>(ParameterExpression parameter, IXPathRetriveConfig<T> config)
		{
			return Expression.Equal(
				Expression.Invoke(config.AttributeValueGetter, parameter, Expression.Constant(this.Name, typeof(string))),
				Expression.Constant(this.Value, typeof(string)));
		}
	}
}