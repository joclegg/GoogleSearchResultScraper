using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GoogleSearchResultScraperApi.Host.Adaptors.Logging
{
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureLogging((context, logging) =>
                logging
                    .AddConfiguration(context.Configuration.GetSection("Logging"))
                    .AddConsole());
    }
}