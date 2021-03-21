using GoogleSearchResultScraperApi.Application.Domain;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoogleSearchResultScraperApi.Application
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureApplication(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureServices((_, services) =>
                services
                    .AddSingleton<ISearchResultUrlsProvider, XPathSearchResultUrlsProvider>()
                    .AddSingleton<ISearchResultUrlsPositionFinder, SearchResultUrlsPositionFinder>()
                    .AddSingleton<IHtmlPageParser, HtmlPageParser>()
                    .AddSingleton<ISearchAnalyser, SearchAnalyser>()
                    .AddMediatR(typeof(HostBuilderExtensions)));
    }
}