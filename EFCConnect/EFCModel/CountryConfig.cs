using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasIndex(c => c.Name).IsUnique();
        builder
            .Property(c => c.Id)
            .HasDefaultValueSql<Guid>("getguid()")
            .ValueGeneratedOnAdd();
    }
}