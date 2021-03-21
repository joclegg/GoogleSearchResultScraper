using Microsoft.AspNetCore.Builder;

namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}