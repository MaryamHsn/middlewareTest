namespace middlewareTest.Services
{
    public class BrowserCheckServices
    {
        public bool Valid(HttpContext context)
        {
            var isEnglish = context.Request.Headers["Accept-Language"].Any(x => x.Contains("en")); 
            return isEnglish;
        }
    }
}
