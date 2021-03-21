using GoogleSearchResultScraperApi.Application.Domain.Html;
using GoogleSearchResultScraperApi.Application.Ports;
using GoogleSearchResultScraperApi.Host.Adaptors.ApplicationConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoogleSearchResultScraperApi.Host.Adaptors.HtmlProvider
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureHtmlProvider(this IHostBuilder hostBuilder) =>
            hostBuilder
                .BindOptions<SearchConfiguration>()
                .ConfigureServices(services =>
                    services
                        .AddSingleton<IHtmlPageProvider, GoogleHtmlPageProvider>()
                        .AddHttpClient<IHtmlPageProvider, GoogleHtmlPageProvider>());
    }
}