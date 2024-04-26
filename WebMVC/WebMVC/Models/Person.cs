using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models;
public class Person
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int? Age {get; set;}

    [DataType(DataType.Password)]
    public string Password {get; set;}

    [DataType(DataType.EmailAddress)]
    public string? Email{get;set;}
}
