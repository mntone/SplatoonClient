using HtmlAgilityPack;
using Mntone.SplatoonClient.Internal;
using Mntone.SplatoonClient.Shared.Internal;
using Mntone.XPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mntone.SplatoonClient
{
    partial class SplatoonContext
    {
		private const string DEFAULT_XPATH = "/html/body/div[@class=\"ika-wrapper ranking\"]/div[@class=\"do\"]/div[@class=\"contents\"]/@data-my-hashed-id";

		private static string ParseMyId(string htmlData, string xpath)
		{
			var doc = new HtmlDocument();
			doc.Load(new StringReader(htmlData));

			var selector = XPathExpression.Compile<HtmlNode, string>(xpath, HtmlAgilityXPathRetriveConfig.Instance);
			return selector(new[] { doc.DocumentNode }).Single();
		}

		public Task<string> GetMyIdAsync() => this.GetMyIdAsync(DEFAULT_XPATH, CancellationToken.None);
		public Task<string> GetMyIdAsync(CancellationToken cancellationToken) => this.GetMyIdAsync(DEFAULT_XPATH, cancellationToken);

		public Task<string> GetMyIdAsync(string xpath) => this.GetMyIdAsync(xpath, CancellationToken.None);
		public Task<string> GetMyIdAsync(string xpath, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(xpath)) throw new ArgumentNullException(nameof(xpath));

			this.AccessCheck();
			return this._client.GetStringWithAccessCheckAsync(SplatoonConstantValues.RANKING_FOR_MY_HASH_ID_URI_TEXT, cancellationToken)
				.ContinueWith(prevTask => ParseMyId(prevTask.Result, xpath));
		}
    }
}
