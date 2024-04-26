using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers;

public class SecuredController : Controller
{

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
}