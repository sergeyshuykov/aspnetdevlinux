using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Person p1 = new Person(){ Name = "Sergey", Age = 46};
    Person p2 = new Person(){ Name = "Andrey", Age = 30};

    //db.People.Add(p1);
    //db.People.Add(p2);
    db.People.AddRange(p1, p2);

    db.SaveChanges();
}

/*
// no need for update within same context
using (ApplicationContext db = new ApplicationContext())
{
    Person p1 = db.People.FirstOrDefault();
    p1.Age++;
    db.SaveChanges();
}
*/
Person px;
using (ApplicationContext db = new ApplicationContext())
{
    px = db.People.FirstOrDefault();
}
using (ApplicationContext db = new ApplicationContext())
{
    px.Age++;
    db.People.Update(px);
    // db.People.Remove(px);
    Console.WriteLine($"Updated person: {px.Name} - {px.Age}");
    int changeRecords = db.SaveChanges();

}


using (var db = new ApplicationContext())
{
    var people = db.People.ToList();
    Console.WriteLine("People list: ");
    foreach(Person person in people)
        Console.WriteLine($"{person.Id}. {person.Name} - {person.Age}");
}

using (var db = new ApplicationContext())
{
    var people = from p in db.People
                 where p.Age < 40
                 orderby p.Name
                 select p;

    Console.WriteLine("People list (age < 40): ");
    foreach(Person person in people) // executing
        Console.WriteLine($"{person.Id}. {person.Name} - {person.Age}");
}