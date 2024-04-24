using Microsoft.AspNetCore.Mvc;
using WebMVC.Filters;
using WebMVC.Models;

namespace WebMVC.Controllers;

[MyActionFilter]
[TypeFilter(typeof(ExFilter))]
public class MyController : Controller 
{
    /*private ILogger logger;
    public MyController(ILogger logger)  // DI
    {
        this.logger = logger;
    }
    
    */
    [Route("my/{a:int}/{b:int}")]
    public IActionResult Index(int a, int b)
    {
        
        try 
        {
            //int a = this.RouteData["a"];
            int result = a / b;
            return View(new {A = a, B = b, Result = result});
        }
        catch(Exception ex)
        {
            //logger.LogError(ex.ToString());
            Console.WriteLine(ex);
            throw;
        }
        //return View(new {A = a, B = b, Result = "undefined"});
    }

    /*
        IActionResult
            ViewResult
            PartialViewResult
            FileContentResult
            StatusCodeResult
            JsonResult
            RedirectResult
            LocalRedirectResult
            RedirectToRouteResult
            RedircetToActionResult
    */

    // my/ParamsObject
    public ContentResult ParamsObject(Person p)
    {
        var c = new ContentResult();
        c.Content = $"<h2>Data from query name: {p.Name} age {p.Age}</h2>";
        c.ContentType = "text/html";
        return c;
    }

    // my/json
    [ActionName("json")]
    public JsonResult JsonAction(Person p)
    {
        return this.Json(p);
    }

    public IActionResult yandex()
    {
        //this.RedirectPermanent
        return this.Redirect("http://yandex.ru");
    }

    public IActionResult GetFile()
    {
        string path = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "test.txt");
        
        return this.PhysicalFile(path, "text/plain");
    }

    public string Params(string name, int age)
    {
        //this.HttpContext.Response.
        return $"Data from query name: {name} age: {age}";
    }

    [TempData]
    public string MyData{ get;set;}

    public IActionResult ToInfo()
    {
        string data = "Data from Toinfo action";
        //ViewBag.data = data; // inside single query
        //TempData["data"] = data;
        MyData = data;
        return this.RedirectToAction("Info");
    }

    public string Info()
    {
        Console.WriteLine("Action info. Route data: ");
        foreach( var v in this.RouteData.Values)
            Console.WriteLine($"{v.Key} : {v.Value}");
        //if (ViewBag.Data != null)
        //    Console.WriteLine($"Data: {ViewBag.data}");
        //if (TempData["data"] != null)
        //    Console.WriteLine("Data: "+TempData["data"]);
        if (MyData != null)
            Console.WriteLine("Data: "+MyData);        

        return "OK";
    }

    [NonAction]
    public string Test()
    {
        return "Test string";
    }
}