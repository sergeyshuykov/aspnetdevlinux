using Microsoft.EntityFrameworkCore;

namespace MyModels;

public class ApplicationContext : DbContext
{

    public DbSet<Course> Courses {get; set;}
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
    }


}

