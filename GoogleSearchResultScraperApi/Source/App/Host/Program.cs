using System;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application;
using GoogleSearchResultScraperApi.Host.Adaptors.ApplicationConfiguration;
using GoogleSearchResultScraperApi.Host.Adaptors.Exceptions;
using GoogleSearchResultScraperApi.Host.Adaptors.HtmlProvider;
using GoogleSearchResultScraperApi.Host.Adaptors.Logging;
using GoogleSearchResultScraperApi.Host.Adaptors.RestApi;
using Microsoft.Extensions.Hosting;

namespace GoogleSearchResultScraperApi.Host
{
    public class Program
    {
        public static async Task Main()
        {
            Console.Title = "GoogleSearchResultScraperApi.Host";
            
            await CreateHostBuilder()
                .Build()
                .RunAsync();
        }

        public static IHostBuilder CreateHostBuilder() =>
            new HostBuilder()
                .ConfigureApplicationConfiguration()
                .ConfigureLogging()
                .ConfigureGlobalExceptionHandlers()
                .ConfigureHtmlProvider()
                .ConfigureRestApi()
                .ConfigureApplication()
                .UseConsoleLifetime();
    }
}