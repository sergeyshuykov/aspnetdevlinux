using MyModels;

public class PersonDaoImpl : IPersonDao
{
    private  IList<Person> people = new List<Person>(){
        new Person(){Id=1, Name = "Sergey", Age = 46},
        new Person(){Id=2, Name = "Andrey", Age = 30},
        new Person(){Id=3, Name = "Konstantin", Age = 18}
    };
    public IList<Person> People => people;
}