public class TrainingMiddleWare
{
    private readonly RequestDelegate next;
    public TrainingMiddleWare(RequestDelegate next)
    {
        next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try{
           var isEnglish =  context.Request.Headers["Accept-Language"].Any(x=>x.Contains("en")); 
           var ischrome =  context.Request.Headers["User-Agent"].Any(x=>x.Contains("Edg"));  
            if(ischrome){
                await context.Response.WriteAsync("just english sitesupported ");
            }
            else
            {
                  await context.Response.WriteAsync("okkkkkkkk");
               // await next(context);
            }
        }
        catch{

        }
      // await CancellationToken CancellationToken => context?.RequestAborted ?? CancellationToken.None;
//catch(OperationCanceledException ex) when (ex.CancellationToken == context.RequestAborted) {     }
    }
}