using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    db.Database.ExecuteSqlRaw(@"
        CREATE OR REPLACE PROCEDURE ""CountPersonOlderThen""(IN minage int, OUT res int) AS
        $$
        BEGIN
        res := (SELECT COUNT(*) FROM ""Person"" WHERE ""PersonAge"" >= minage);
        END
        $$ LANGUAGE plpgsql;
        ");
    db.Database.ExecuteSqlRaw(@"
        CREATE FUNCTION ""PersonOlderThen""(in minage integer) RETURNS SETOF ""Person"" AS $$
        BEGIN
        RETURN QUERY SELECT * FROM ""Person"" WHERE ""PersonAge"" >= minage;
        END;
        $$ LANGUAGE plpgsql;
    ");


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

using (var db = new ApplicationContext())
{
    var people = db.PersonOlderThen( 35 );
    Console.WriteLine("People list (age > 35): ");
    foreach(Person person in people)
        Console.WriteLine($"{person.Id}. {person.Name} - {person.Age}");

    int x = db.CountPersonOlderThen(35);
    Console.WriteLine(x);
}