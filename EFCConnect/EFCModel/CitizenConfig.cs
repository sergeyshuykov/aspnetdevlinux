using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CitizenConfig : IEntityTypeConfiguration<Citizen>
{
    public void Configure(EntityTypeBuilder<Citizen> builder)
    {
        builder
            .HasKey(c => new { c.PassportSerial, c.PassportNumber}); // complex key
        
        builder
            .Property<string>(c => c.Passport)
            .HasComputedColumnSql("'PassportSerial' + ' ' + CAST('PassportNumber' AS text)");

        builder
            .Property<string>(c => c.PassportSerial)
            //.HasMaxLength(10)
            .HasDefaultValueSql("'AB-CD'");
    }
}