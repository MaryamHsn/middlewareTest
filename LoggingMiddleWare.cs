using Microsoft.AspNetCore.Http.Features;
using System.Security.Cryptography.Xml;
using System.Text;

namespace middlewareTest
{
    public class LoggingMiddleWare :IMiddleware
    {
       // private readonly RequestDelegate _next; 
        private readonly ILogger<LoggingMiddleWare> _logger;
        //public LoggingMiddleWare( RequestDelegate next)
        //{
        //    _next = next; 
        //}
        //public async  Task InvokeAsync(HttpContext context)
        //{

            
        //    _logger.LogInformation("Before");
        //    await _next(context);
        //    _logger.LogInformation("After"); 
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Before");
            await next(context);
            _logger.LogInformation("After");
        }
    }
}
