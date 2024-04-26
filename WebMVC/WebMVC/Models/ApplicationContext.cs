using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace MyModels;

public class ApplicationContext : DbContext
{

    public DbSet<Course> Courses {get; set;}
    public DbSet<Person> Person {get; set;}
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        //options.
        this.Database.EnsureDeleted();
        this.Database.EnsureCreated();

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Course>().HasData
        (
            new Course(){Id = 1, Title = "C#", Duration = 40, Description = "C# Intro"},
            new Course(){Id = 2, Title = "Git", Duration = 24, Description = "Git intro"},
            new Course(){Id = 3, Title = "ASP.NET Linux", Duration = 40, Description = "ASP.NET MVC for Linux"}
        );
        modelBuilder.Entity<Person>().HasData
        (
            new Person(){Id = 1, Name = "Sergey", Password = "abc"},
            new Person(){Id = 2, Name = "Andrey", Password = "cba"},
            new Person(){Id = 3, Name = "root", Password= "a123"}
        );
    }


}

