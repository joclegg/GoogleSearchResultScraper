using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    internal interface IHtmlPageParser
    {
        Task<int[]> GetPositions(string page, string url, CancellationToken cancellationToken);
    }
}