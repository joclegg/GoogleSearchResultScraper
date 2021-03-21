using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoogleSearchResultScraperApi.Host.Adaptors.ApplicationConfiguration
{
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureApplicationConfiguration(this IHostBuilder hostBuilder) =>
            hostBuilder
                .ConfigureHostConfiguration(configuration =>
                    configuration.SetBasePath(Directory.GetCurrentDirectory()))
                .ConfigureAppConfiguration((_, configuration) =>
                    configuration
                        .AddJsonFile("appsettings.json", false, true));

        public static IHostBuilder BindOptions<TOptions>(this IHostBuilder hostBuilder)
            where TOptions : class =>
            hostBuilder
                .BindOptions<TOptions>(typeof(TOptions).Name);

        public static IHostBuilder BindOptions<TOptions>(this IHostBuilder hostBuilder, string section)
            where TOptions : class =>
            hostBuilder
                .ConfigureServices((context, services) =>
                    services
                        .AddOptions<TOptions>()
                        .Bind(context.Configuration.GetSection(section)));
    }
}