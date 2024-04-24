using Microsoft.Extensions.FileProviders;
using WebMVC;
using WebMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHello, HelloImpl>();
//builder.Services.AddKeyedSingleton<IHello, HelloImpl>("one");

var app = builder.Build();

// not recommnded
//app.Services.GetService(IHello)

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
    app.UseDeveloperExceptionPage();

//app.UseHttpsRedirection();
app.UseStaticFiles(); // wwwroot

app.UseStaticFiles(new StaticFileOptions{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "MyStatic"))
});

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "hello",
    pattern : "ola/{UserName?}",
    defaults : new { controller = "Hello", action = "Index" }
);

// /Hello/Hi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
