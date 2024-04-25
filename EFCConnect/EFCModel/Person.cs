using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Person")]
public class Person
{
    // public int PersonId {get; set;}
    // [Key]
    public int Id {get; set;}
    
    [Required]
    public string? Name {get; set;}
    
    [Column("PersonAge")]
    public int Age {get; set;}

    [NotMapped]
    public string? Address {set; get;}

    public virtual List<Country> Countries {get; set;}

}
