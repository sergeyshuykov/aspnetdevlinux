using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationContext : DbContext
{


    public DbSet<Person> People { get; set; }
    public DbSet<Country> Country { get; set; }

    public DbSet<Citizen> Citizen { get; set; }
    public DbSet<Company> Company { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string connectionString = MyConfig.Config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);

        optionsBuilder.LogTo(s => Debug.WriteLine(s));
        //optionsBuilder.LogTo(Console.WriteLine);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Fluent API

        modelBuilder.ApplyConfiguration(new CountryConfig());
        /*modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Country>()
            .Property(c => c.Id)
            .HasDefaultValueSql<Guid>("getguid()")
            .ValueGeneratedOnAdd();*/

        
        modelBuilder.Entity<Person>()
            .HasMany(p => p.Countries)
            .WithMany(c => c.People)
            //.UsingEntity(j => j.ToTable("citizenship")) // custom join table
            .UsingEntity<Citizen>();
    }
}