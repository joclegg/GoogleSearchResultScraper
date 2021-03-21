using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using GoogleSearchResultScraperApi.Application.Ports;
using Microsoft.Extensions.Options;

namespace GoogleSearchResultScraperApi.Host.Adaptors.HtmlProvider
{
    // Could probably decorate this with a retry policy for resiliency
    public class GoogleHtmlPageProvider : IHtmlPageProvider
    {
        private const string BaseAddress = "https://google.co.uk";
        private readonly HttpClient httpClient;
        private readonly IOptionsMonitor<SearchConfiguration> options;

        public GoogleHtmlPageProvider(
            HttpClient httpClient,
            IOptionsMonitor<SearchConfiguration> options)
        {
            this.httpClient = httpClient;
            this.options = options;
        }
        
        public async Task<string> GetPage(string searchTerm, CancellationToken cancellationToken)
        {
            var urlSearchTerm = searchTerm.Replace(' ', '+');
            return await httpClient.GetStringAsync(
                $"{BaseAddress}/search?num={options.CurrentValue.MaxSearchTerms}&q={urlSearchTerm}", cancellationToken);
        }
    }
}