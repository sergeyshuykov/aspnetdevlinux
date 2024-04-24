var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IPersonDao, PersonDaoImpl>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();


app.Run();
