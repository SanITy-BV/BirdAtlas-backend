using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BirdAtlas.Api.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogException(context);

            await WriteResponse(context);

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private void LogException(HttpContext context)
        {
            var exHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exHandlerFeature.Error;

            _logger.LogError(
                new EventId(exception.HResult),
                exception,
                exception.Message);
        }

        private Task WriteResponse(HttpContext context)
        {
            var result = new ObjectResult(new[] { "An error occured. Please try again." });

            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = result.StatusCode.HasValue ? result.StatusCode.Value : StatusCodes.Status500InternalServerError;
            }
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}