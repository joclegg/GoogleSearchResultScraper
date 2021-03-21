using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;

namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    internal class XPathSearchResultUrlsProvider : ISearchResultUrlsProvider
    {
        private readonly IOptionsMonitor<SearchConfiguration> options;

        public XPathSearchResultUrlsProvider(IOptionsMonitor<SearchConfiguration> options)
        {
            this.options = options;
        }
        
        public Task<string[]> GetUrls(string page, CancellationToken cancellationToken)
        {
            var pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(page);
            var nodes = pageDocument.DocumentNode.SelectNodes(options.CurrentValue.XPathPattern);
            return Task.FromResult(nodes == null ?
                Array.Empty<string>() : 
                nodes
                    .Select(x => x.InnerHtml)
                    .ToArray());
        }
    }
}