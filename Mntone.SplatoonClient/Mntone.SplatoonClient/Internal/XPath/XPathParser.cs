using System;
using System.Text.RegularExpressions;

namespace Mntone.SplatoonClient.Internal.XPath
{
	public sealed class XPathParser
	{
		private static readonly string[] ATTRIBUTE_COMBINATORS = new string[] { "@", "attribute::" };
		private static readonly string[] HIERARCHY_COMBINATORS = new string[] { /*"//",*/ "/", /*"|"*/ };
		private static readonly Regex ELEMENT_INDEX = new Regex(@"\G\[\d+\]");

		public string Query { get; }
		private readonly TokenQueue _queue;

		private RootXPathExpressionBuilder _builder = new RootXPathExpressionBuilder();
		private HierarchyXPathExpressionBuilder _previous = null;
		private HierarchyXPathExpressionBuilder _current = null;

		public XPathParser(string xpath)
		{
			this.Query = xpath;
			this._queue = new TokenQueue(xpath);
		}

		public RootXPathExpressionBuilder Parse()
		{
			var current = this._queue.Position;
			while (!this._queue.IsEmpty)
			{
				this.AnalysisElements();
				this._queue.ConsumeWhitespaces();

				if (current == this._queue.Position) throw new Exception();
				current = this._queue.Position;
			}
			return this._builder;
		}

		private void AnalysisElements()
		{
			string buf = null;
			if ((buf = this._queue.MatchesAny(HIERARCHY_COMBINATORS)) != null)
			{
				this._queue.Advance(buf);

				var builder = new ChildrenPathXPathExpressionBuilder();
				this.AppendChild(builder);
				return;
			}
			else if ((buf = this._queue.MatchesAny(ATTRIBUTE_COMBINATORS)) != null)
			{
				this._queue.Advance(buf);

				var name = this._queue.MatchName();
				if (name == null) throw new Exception();
				var builder = new AttributeXPathExpressionBuilder(name);
				this.ReplaceChild(builder);
				return;
			}
			else if (this._queue.Match('*'))
			{
				this._queue.Advance('*');
				return;
			}
			else if (this._queue.Match("text()"))
			{
				this._queue.Advance("text()");
				var builder = new TextXPathExpressionBuilder();
				this.ReplaceChild(builder);
				return;
			}
			else if ((buf = this._queue.MatchName()) != null)
			{
				this._queue.Advance(buf);
				this._current.Conditions.Add(new TagNameXPathCondition(buf));
				return;
			}
			else if ((buf = this._queue.MatchRegex(ELEMENT_INDEX)) != null)
			{
				this._queue.Advance(buf);

				var idx = Convert.ToInt32(buf.Substring(1, buf.Length - 2));
				var builder = new IndexXPathExpressionBuilder(idx);
				this.AppendChild(builder);
				return;
			}
			else if (this._queue.Match('['))
			{
				this._queue.Advance('[');

				this.AnalysisPredicates();
				return;
			}

			throw new Exception();
		}

		private void AnalysisPredicates()
		{
			this._queue.ConsumeWhitespaces();

			string buf = null;
			if ((buf = this._queue.MatchesAny(ATTRIBUTE_COMBINATORS)) != null)
			{
				this._queue.Advance(buf);
			}

			var begin = this._queue.Position;
			while (!this._queue.IsEmpty && !this._queue.Match('=')) this._queue.Advance('=');

			var name = this._queue.Data.Substring(begin, this._queue.Position - begin).Trim(TokenQueue.WHITESPACE);

			this._queue.Advance('=');
			this._queue.ConsumeWhitespaces();

			var value = this._queue.MatchNameWithQuote(true);

			this._queue.ConsumeWhitespaces();

			if (!this._queue.Match(']')) throw new Exception();
			this._queue.Advance(']');

			this._current.Conditions.Add(new AttributeXPathCondition(name, value));
		}

		private void AppendChild(HierarchyXPathExpressionBuilder builder)
		{
			XPathExpressionBuilder target = this._current;
			if (target == null) target = this._builder;
			target.Child = builder;

			this._previous = this._current;
			this._current = builder;
		}

		private void ReplaceChild(HierarchyXPathExpressionBuilder builder)
		{
			XPathExpressionBuilder target = this._previous;
			if (target == null) target = this._current;
			if (target == null) target = this._builder;
			target.Child = builder;

			this._current = builder;
		}
	}
}