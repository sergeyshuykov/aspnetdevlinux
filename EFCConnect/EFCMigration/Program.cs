using Microsoft.EntityFrameworkCore;

using (var db = new ApplicationContext()){
    db.Database.Migrate();
}
 

using (var db = new ApplicationContext())
{
    var people = db.People.ToList();
    Console.WriteLine("People list: ");
    foreach(Person person in people)
        Console.WriteLine($"{person.Id}. {person.Name} - {person.Age}");
}
