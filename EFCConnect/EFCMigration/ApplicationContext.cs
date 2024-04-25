using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationContext : DbContext
{


    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string connectionString = MyConfig.Config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);

        //optionsBuilder.LogTo(s => Debug.WriteLine(s));
        optionsBuilder.LogTo(Console.WriteLine);

    }
}