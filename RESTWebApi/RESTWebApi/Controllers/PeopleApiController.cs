using Microsoft.AspNetCore.Mvc;
using MyModels;

//[Route("api/[controller]")]
[Route("api/people")]
[ApiController]
public class PeopleApiController : ControllerBase
{
    private IPersonDao dao;
    public PeopleApiController(IPersonDao dao) => this.dao = dao;

    // GET: api/people
    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        return dao.People;
    }

    // GET: api/people/5
    [HttpGet("{id}")]
    public ActionResult<Person> GetPerson(int id)
    {
        Person p = dao.People.Where(p => p.Id ==id).SingleOrDefault();
        if (p == null) return this.NotFound();
        return p;
    }

    // POST : api/people
    [HttpPost]
    public ActionResult<Person> AddPerson(Person person)
    {
        if(person == null)
            return this.Problem("Entity Person is null");

        person.Id = dao.People.Select(p => p.Id).Max()+1;
        dao.People.Add(person);
        return CreatedAtAction("GetPerson", new {id = person.Id}, person);
    }

}