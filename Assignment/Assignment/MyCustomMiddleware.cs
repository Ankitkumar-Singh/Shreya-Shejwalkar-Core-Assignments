using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Assignment
{   
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyCustomMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("My Custom Middleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("My Custom Middleware executing..");
            await _next(httpContext); // calling next middleware
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
