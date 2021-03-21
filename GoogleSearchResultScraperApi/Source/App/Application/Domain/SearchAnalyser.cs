using System.Threading;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using GoogleSearchResultScraperApi.Application.Ports;

namespace GoogleSearchResultScraperApi.Application.Domain
{
    internal class SearchAnalyser : ISearchAnalyser
    {
        private readonly IHtmlPageProvider provider;
        private readonly IHtmlPageParser parser;

        public SearchAnalyser(
            IHtmlPageProvider provider,
            IHtmlPageParser parser)
        {
            this.provider = provider;
            this.parser = parser;
        }
        
        public async Task<int[]> GetSearchResultPositions(string searchTerm, string url, CancellationToken cancellationToken)
        {
            var page = await provider.GetPage(searchTerm, cancellationToken).ConfigureAwait(false);
            return await parser.GetPositions(page, url, cancellationToken);
        }
    }
}