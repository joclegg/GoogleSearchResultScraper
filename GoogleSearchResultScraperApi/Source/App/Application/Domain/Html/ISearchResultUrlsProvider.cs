using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    internal interface ISearchResultUrlsProvider
    {
        Task<string[]> GetUrls(string page, CancellationToken cancellationToken);
    }
}