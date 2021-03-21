using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    internal class HtmlPageParser : IHtmlPageParser
    {
        private readonly ISearchResultUrlsProvider urlsProvider;
        private readonly ISearchResultUrlsPositionFinder urlsPositionFinder;

        public HtmlPageParser(
            ISearchResultUrlsProvider urlsProvider,
            ISearchResultUrlsPositionFinder urlsPositionFinder)
        {
            this.urlsProvider = urlsProvider;
            this.urlsPositionFinder = urlsPositionFinder;
        }
        
        public async Task<int[]> GetPositions(string page, string url, CancellationToken cancellationToken)
        {
            var urls = await urlsProvider.GetUrls(page, cancellationToken).ConfigureAwait(false);
            return await urlsPositionFinder.GetPositions(urls, url, cancellationToken).ConfigureAwait(false);
        }
    }
}