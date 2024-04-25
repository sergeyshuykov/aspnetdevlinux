using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[EntityTypeConfiguration(typeof(CitizenConfig))]
public class Citizen
{
    [MaxLength(10)]
    public string PassportSerial {get; set;}
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PassportNumber{get; set;}

    // computed value : [PassportSerial PassportNumber]
    public string Passport {get; set;}

    public string? Name {get; set;}

    public int PersonId {get; set;}
    public Guid CountryId {get; set;}

}