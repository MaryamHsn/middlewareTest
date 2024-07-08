using middlewareTest;
using middlewareTest.Extension;
using middlewareTest.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next)=>{
    app.Logger.LogInformation("start");
    await next(context); 
    app.Logger.LogInformation("End");
});


app.Use(async(context,next)=>
{
    try
    {
            // context.response.write("handle error");
            await next(context);
    }
    catch (System.Exception)
    {
        app.Logger.LogError("handle error failed");
    }    
});
//middleware to check language of site
app.Use(async (context, next) =>{
    var browserCheck = new BrowserCheckServices();
    if (browserCheck.Valid(context))
    {
        await next(context);
    }
    else
    {
        await context.Response.WriteAsync("just english sites are supported ");
    }

});

app.UseBrowserCheck(app.Environment);
app.UseMiddleware<TrainingMiddleWare>();
app.UseMiddleware<LoggingMiddleWare>();
//app.Environment.IsEnvironment("QA") ;

app.MapGet("/", () => "Hello World!");
app.MapGet(
    "/error",
    ()=>
    {
        throw new Exception("erro");
    }
); 
app.Run();
