using middlewareTest.Services;
using System.ComponentModel.DataAnnotations;

namespace middlewareTest
{
    public class BrowserCheckMiddelWare
    {
        private readonly RequestDelegate _next;
        public BrowserCheckMiddelWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var browserCheck = new BrowserCheckServices();
                if (browserCheck.Valid( context))
                {
                    await _next(context);
                }
                else
                {
                    await context.Response.WriteAsync("just english sites are supported ");
                }
            }
            catch
            {

            }
        }
    }
}
