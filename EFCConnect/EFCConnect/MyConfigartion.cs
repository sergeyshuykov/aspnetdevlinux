using Microsoft.Extensions.Configuration;

public static class MyConfig
{

    public static IConfiguration Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
}