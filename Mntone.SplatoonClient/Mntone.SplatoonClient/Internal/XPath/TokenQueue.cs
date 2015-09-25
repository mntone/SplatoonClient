using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mntone.SplatoonClient.Internal.XPath
{
	internal sealed class TokenQueue
	{
		internal static readonly char[] WHITESPACE = new char[] { ' ', '\t', '\r', '\n' };
		private const string NAME_START_CHARACTORS = @"(?:[:A-Z_a-z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02FF\u0370-\u037D\u037F-\u1FFF\u200C-\u200D\u2070-\u218F\u2C00-\u2FEF\u3001-\uD7FF\uF900-\uFDCF\uFDF0-\uFFFD]|[\uD800-\uDB7F][\DC00-\uDFFF])";
		private const string NAME_CHARACTORS = @"(?:[\-\.0-9:A-Z_a-z\u00B7\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02FF\u0300-\u037D\u037F-\u1FFF\u200C-\u200D\u203F-\u2040\u2070-\u218F\u2C00-\u2FEF\u3001-\uD7FF\uF900-\uFDCF\uFDF0-\uFFFD]|[\uD800-\uDB7F][\DC00-\uDFFF])";
		private static readonly Regex NAME = new Regex(@"\G(?:" + NAME_START_CHARACTORS + NAME_CHARACTORS + "*)");

		public string Data { get; }
		public int Position { get; private set; } = 0;

		public bool IsEmpty { get { return this.RemainingLength == 0; } }
		public int RemainingLength { get { return this.Data.Length - this.Position; } }

		public TokenQueue(string data)
		{
			this.Data = data;
		}

		public TokenQueue Clone()
		{
			return new TokenQueue(this.Data)
			{
				Position = this.Position,
			};
		}

		public bool Match(char target) => this.Data[this.Position] == target;
		public bool Match(string target) => string.Compare(this.Data, this.Position, target, 0, target.Length) == 0;
		internal char? MatchesAnyInternal(char[] targets)
		{
			foreach (var target in targets)
			{
				if (this.Match(target)) return target;
			}
			return null;
		}
		internal string MatchesAnyInternal(string[] targets) => targets.FirstOrDefault(target => this.Match(target));

		public string MatchRegex(Regex target)
		{
			var match = target.Match(this.Data, this.Position);
			if (!match.Success) return null;
			return match.Value;
		}
		public string MatchName() => this.MatchRegex(NAME);

		private string MatchNameWithQuoteInternal(char target, bool isAdvance)
		{
			var begin = this.Position + 1;
			var current = begin;
			while (this.Data.Length != current && this.Data[current] != target) ++current;
			var result = this.Data.Substring(begin, current++ - begin);
			if (isAdvance) this.Position = current;
			return result;
		}

		public string MatchNameWithQuote(bool isAdvance = false)
		{
			if (this.Match('\'')) return this.MatchNameWithQuoteInternal('\'', isAdvance);
			if (this.Match('"')) return this.MatchNameWithQuoteInternal('"', isAdvance);

			var result = this.MatchName();
			if (isAdvance) this.Position += result.Length;
			return result;
		}

		public char? MatchesAny(char[] targets)
		{
			if (targets == null) return null;
			return this.MatchesAnyInternal(targets);
		}

		public string MatchesAny(string[] targets)
		{
			if (targets == null) return null;
			return this.MatchesAnyInternal(targets);
		}

		public char? MatchWhitespace() => this.MatchesAnyInternal(WHITESPACE);

		public bool Consume(char target)
		{
			if (!this.Match(target)) return false;

			++this.Position;
			return true;
		}

		public bool Consume(string target)
		{
			if (!this.Match(target)) return false;

			this.Position += target.Length;
			return true;
		}

		private bool ConsumeLoop(Func<bool> predicate)
		{
			bool seen = false;
			while (!IsEmpty && predicate())
			{
				++this.Position;
				seen = true;
			}
			return seen;
		}

		public bool ConsumeWhitespaces() => this.ConsumeLoop(() => this.MatchWhitespace() != null);

		public void Advance(int target) => this.Position += target;
		public void Advance(char target) => ++this.Position;
		public void Advance(string target) => this.Position += target.Length;
	}
}