using System.Runtime.CompilerServices;

namespace middlewareTest.Extension
{
    public static class BrowserCheckMiddelWareExtension
    {
        public static void UseBrowserCheck(this IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseMiddleware<BrowserCheckMiddelWare>();
            }
        }
    }
}


