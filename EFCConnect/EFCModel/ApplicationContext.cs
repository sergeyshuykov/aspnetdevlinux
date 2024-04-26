using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;

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

    public int CountPersonOlderThen(int minAge = 18)
    {
       
        using(NpgsqlConnection conn = this.Database.GetDbConnection() as NpgsqlConnection)
        {
            conn.Open();
            IDbCommand command = conn.CreateCommand();
            command.CommandText = "\"CountPersonOlderThen\"";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new NpgsqlParameter("@minage", minAge));
            
            NpgsqlParameter outParm = new NpgsqlParameter("@res", NpgsqlDbType.Integer)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outParm);

            command.ExecuteNonQuery();
            return (int)outParm.Value;        
        }


        //var r = this.Database.ExecuteSqlInterpolated(
        //    $"CALL \"CountPersonOlderThen\" ( {minAge} )");
        //this.People.FromSqlInterpolated<Person>($"")

    }
    public IQueryable<Person> PersonOlderThen(int minage)  => FromExpression(() => PersonOlderThen(minage));
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

        // Заполение данными
        modelBuilder.Entity<Person>().HasData(
            new Person(){Id=1, Name = "Sergey", Age = 46},
            new Person(){Id=2, Name = "Andrey", Age = 30},
            new Person(){Id=3, Name = "Konstantin", Age = 17}
        );

        modelBuilder.HasDbFunction(() => PersonOlderThen(default));
        

    }
}