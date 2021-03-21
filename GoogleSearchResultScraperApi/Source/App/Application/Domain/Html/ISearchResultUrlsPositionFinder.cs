using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    internal interface ISearchResultUrlsPositionFinder
    {
        Task<int[]> GetPositions(string[] urls, string url, CancellationToken cancellationToken);
    }
}