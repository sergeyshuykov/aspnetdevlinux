using Microsoft.AspNetCore.Mvc.Rendering;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.Use
// app.Run
// app.Map (app.MapWhen)

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error.html");

app.Use(async (context, next) => {
    context.Response.ContentType = "text/html";
    await next();
});

//app.MapGet("/", () => "Hello World!");

app.Map("/test", appBuilder=>{
    appBuilder.Run( async context => {
        await context.Response.SendFileAsync("test.txt"); });
});

app.Map("/json", appBuilder=>{
    appBuilder.Run(async context=>{
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { Title = "ASP.NET Core for Linux", Duration = 40});
    });
});

app.Use(
    async (context, next) => {
        if (context.Request.Method == HttpMethods.Get)
        {
            await context.Response.WriteAsync("Start First middleware ");
            //throw new Exception("Test exception from my middleware");
        }
        
        await next();
        await context.Response.WriteAsync("End First Middleware");
    }
);

app.Map("/security", appBuilder=>{
    
    // /security/login
    appBuilder.Map("/login", ab2=>{
        ab2.Run(async context => {await context.Response.WriteAsync("Login page.");});
    });

    // /security/register
    appBuilder.Map("/register", ab2=>{
        ab2.Run(async context => {await context.Response.WriteAsync("Register page.");});
    });
    appBuilder.Map("/date", ab2=>{
        ab2.Run(async context => {await context.Response.WriteAsync("Date page from security");});
    });
});

app.UseMiddleware<SecondMiddleware>();

app.UseWhen( context => context.Request.Path.Value.Contains("time"),
    appBuilder => {
        appBuilder.Use(async (context, next) => {
            await context.Response.WriteAsync("UseWhen() /time");
            await next();
        });
    }
);

app.MapWhen(context => context.Request.Headers.ContainsKey("date"),//context.Request.Path.Value.Contains("date"),
    appBuilder=>{
        appBuilder.Use( async (context, next) =>{
            await context.Response.WriteAsync("MapWhen() date");
            await next();
        });
    }
);


app.Run(async context => {
    //context.Response.Redirect
    await context.Response.WriteAsync("<h1> Hello from Run(...)</h1>");
});

app.Run();
