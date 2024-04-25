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


using (var db = new ApplicationContext())
{
    var people = db.People.ToList();
    Console.WriteLine("People list: ");
    foreach(Person person in people)
        Console.WriteLine($"{person.Id}. {person.Name} - {person.Age}");
}
