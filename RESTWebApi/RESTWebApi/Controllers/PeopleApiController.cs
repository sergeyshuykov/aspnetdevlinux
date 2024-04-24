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

}