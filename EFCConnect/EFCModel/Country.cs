using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

//[Index("Name", IsUnique = true, Name = "IndexName")]
public class Country
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id {get; set;}

    public string? Name {get; set;}

    public virtual List<Person> People {get; set;}


}