using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        private readonly RequestDelegate next;
        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions {WriteIndented = true};

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var headers = JsonSerializer.Serialize((IDictionary<string, StringValues>)httpContext.Request.Headers, jsonOptions);
                var queryString = JsonSerializer.Serialize(httpContext.Request.QueryString, jsonOptions);
                logger.LogError(ex,$"Error calling path: {httpContext.Request.Path} with request headers: {headers} and query string: {queryString}");

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            const HttpStatusCode code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = exception.Message }, jsonOptions);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;
            return httpContext.Response.WriteAsync(result);
        }
    }
}
