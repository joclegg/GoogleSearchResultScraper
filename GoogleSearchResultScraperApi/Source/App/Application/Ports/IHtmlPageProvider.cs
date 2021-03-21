using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Ports
{
    public interface IHtmlPageProvider
    {
        Task<string> GetPage(string searchTerm, CancellationToken cancellationToken);
    }
}