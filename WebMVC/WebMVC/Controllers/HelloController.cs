using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers;

public class HelloController: Controller
{
    private IHello hello;
    public HelloController(/*[FromKeyedServices("one")]*/ IHello hello) => this.hello = hello;

    [HttpGet]
    public IActionResult Index()
    {
        return this.View(new HelloVM());
    }

    // DataBinding source
    // FormData this.HttpContext.Request.Form
    // RouteData this.RouteData
    // GetData this.HttpContext.Request.QueryString
    // File
    
    // [Route("say/{UserName}/{Age:int}")]
    // [Route("say2")] // say2?Age=40&UserName=Sergey
    //public IActionResult say(int Age, string UserName) // binding

    [HttpPost]
    public IActionResult SayHello(HelloVM m) // binding
    {
        
        
        if (!this.ModelState.IsValid)
            // сообщим пользователю об ошибке в данных
            // и вернуть ту же View
            ViewBag.MyErrorMessage = "Некорректные данные";
            //ViewData["MyErrorMessage"]
        //else
            // работаем с данных
        return View("Index", m);
    }

    
    [HttpGet]
    [Route("hi/{UserName?}")] // /hi/sergey
    [Route("privet")] // privet?UserName=Sergey
    public IActionResult Hi(HelloVM m)
    {
        return View("Index", m);
    }

    [HttpGet]
    public IActionResult IndexSrv()
    {
        // this.HttpContext.RequestServices.GetService
        
        var m = new HelloVMSrv();
        m.Hello = hello.GetHelloString(m.UserName);
        return this.View(m);
    }
    [HttpPost]
    public IActionResult SayHelloSrv(HelloVMSrv m) // binding
    {
        if (!this.ModelState.IsValid)
            ViewBag.MyErrorMessage = "Некорректные данные";
        m.Hello = hello.GetHelloString(m.UserName);
        return View("IndexSrv", m);
    }

}