using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Domain
{
    internal interface ISearchAnalyser
    {
        Task<int[]> GetSearchResultPositions(string searchTerm, string url, CancellationToken cancellationToken);
    }
}