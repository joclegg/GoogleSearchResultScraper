using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GoogleSearchResultScraperApi.Host.Adaptors.Exceptions
{
    [ExcludeFromCodeCoverage]
    internal static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureGlobalExceptionHandlers(this IHostBuilder hostBuilder) =>
            hostBuilder
                .ConfigureServices(services =>
                {
                    var logger = services.BuildServiceProvider().GetRequiredService<ILogger<HostBuilder>>();
                    TaskScheduler.UnobservedTaskException += OnUnobservedTaskException(logger);
                    AppDomain.CurrentDomain.UnhandledException += OnUnhandledException(logger);
                });
        
        private static EventHandler<UnobservedTaskExceptionEventArgs> OnUnobservedTaskException(ILogger logger) =>
            (_, args) =>
            {
                logger.LogError(
                    args.Exception?.Flatten(),
                    "Unobserved task exception occurred");
            };
        
        private static UnhandledExceptionEventHandler OnUnhandledException(ILogger logger) =>
            (_, args) =>
            {
                var message = args.IsTerminating
                    ? "Unhandled exception occurred and CLR is terminating, stopping service..."
                    : "Unhandled exception occurred, CLR is not terminating and behaviour at this point is undefined.";
                        
                logger.LogError(
                    (Exception)args.ExceptionObject,
                    message);
            };
    }
}