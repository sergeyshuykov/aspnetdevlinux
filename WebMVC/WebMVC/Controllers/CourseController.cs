using Microsoft.AspNetCore.Mvc;
using MyModels;

namespace WebMVC.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        return View(Course.All);
    }
}