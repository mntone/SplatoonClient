using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Mntone.SplatoonClient.Internal.XPath
{
	internal abstract class XPathExpressionBuilder
	{
		public XPathExpressionBuilder Child { get; set; }

		protected Expression BuildChild<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var builder = this.Child as HierarchyXPathExpressionBuilder;
			if (builder == null) return exp;
			return builder.Build(exp, config);
		}
	}

	internal sealed class RootXPathExpressionBuilder
		: XPathExpressionBuilder
	{
		internal RootXPathExpressionBuilder() { }

		internal Func<IEnumerable<TIn>, IEnumerable<TOut>> Build<TIn, TOut>(IXPathRetriveConfig<TIn> config)
		{
			var input = Expression.Parameter(typeof(IEnumerable<TIn>), "input");
			var childExp = this.BuildChild(input, config);
			return (Func<IEnumerable<TIn>, IEnumerable<TOut>>)Expression.Lambda(childExp, input).Compile();
		}
	}

	internal abstract class HierarchyXPathExpressionBuilder : XPathExpressionBuilder
	{
		public List<XPathCondition> Conditions { get; } = new List<XPathCondition>();

		public abstract Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config);
	}

	internal sealed class ChildrenPathXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var node2Parameter = Expression.Parameter(typeof(T), "node2");
			var parentExp = Expression.Call(
				typeof(Enumerable),
				"SelectMany",
				new[] { typeof(T), typeof(T) },
				exp,
				this.Conditions.Count == 0
					? config.ChildrenGetter
					: Expression.Lambda(
						Expression.Call(
							typeof(Enumerable),
							"Where",
							new[] { typeof(T) },
							Expression.Invoke(config.ChildrenGetter, nodeParameter),
							this.Conditions.Select(c => c.Build(node2Parameter, config)).ToAndLambda(node2Parameter)),
						nodeParameter));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}

	[DebuggerDisplay("Index = {this.Index}")]
	internal sealed class IndexXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public int Index { get; }

		public IndexXPathExpressionBuilder(int index)
		{
			this.Index = index;
		}

		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var parentExp = Expression.NewArrayInit(
				typeof(T),
				Expression.Call(
					typeof(Enumerable),
					"ElementAt",
					new[] { typeof(T) },
					exp,
					Expression.Constant(this.Index - 1, typeof(int))));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}

	[DebuggerDisplay("Name = {this.Name}")]
	internal sealed class AttributeXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public string Name { get; }

		public AttributeXPathExpressionBuilder(string name)
		{
			this.Name = name;
		}

		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var parentExp = Expression.Call(
				typeof(Enumerable),
				"Select",
				new[] { typeof(T), typeof(string) },
				exp,
				Expression.Lambda(
					Expression.Invoke(config.AttributeValueGetter, nodeParameter, Expression.Constant(this.Name, typeof(string))),
					nodeParameter));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}

	internal sealed class TextXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var parentExp = Expression.Call(
				typeof(Enumerable),
				"Select",
				new[] { typeof(T), typeof(string) },
				exp,
				Expression.Lambda(
					Expression.Invoke(config.TextGetter, nodeParameter),
					nodeParameter));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}
}