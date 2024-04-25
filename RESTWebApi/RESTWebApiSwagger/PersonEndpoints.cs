public static class PersonEndpoints
{
    public static void MapPersonEndPoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("api/people");

        group.MapGet("/", () => Person.People)
        .WithName("getAllPeople")
        .WithOpenApi()
        .Produces<List<Person>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", (int id)=>{
            Person p = Person.People.Where(p => p.Id ==id).SingleOrDefault();
            return (p != null) ? Results.Ok(p) : Results.NotFound();
        })
        .WithName("GetPersonById")
        .WithOpenApi()
        .Produces<Person>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        
    }
}