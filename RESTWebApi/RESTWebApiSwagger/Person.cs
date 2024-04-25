using System.ComponentModel.DataAnnotations;

public class Person
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int Age {get; set;}

    private  static IList<Person> people = new List<Person>(){
        new Person(){Id=1, Name = "Sergey", Age = 46},
        new Person(){Id=2, Name = "Andrey", Age = 30},
        new Person(){Id=3, Name = "Konstantin", Age = 18}
    };
    public static IList<Person> People => people;    

    
}
