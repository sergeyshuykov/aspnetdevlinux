using Microsoft.AspNetCore.Mvc;
using MyModels;

namespace WebMVC.Controllers;

public class CourseController : Controller
{
    private ApplicationContext db;
    
    public CourseController(ApplicationContext db) => this.db = db;
    public IActionResult Index()
    {
        return View(db.Courses.ToList());
    }
}