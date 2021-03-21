using GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureRestApi(this IHostBuilder hostBuilder) =>
            hostBuilder
                .ConfigureServices(services => 
                    services
                        .AddSingleton<IResultTranslator, ResultTranslator>())
                .ConfigureWebHost(builder =>
                    builder
                        .UseKestrel()
                        .UseStartup<Startup>());
    }
}