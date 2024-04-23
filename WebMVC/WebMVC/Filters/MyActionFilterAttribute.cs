using Microsoft.AspNetCore.Mvc.Filters;
namespace WebMVC.Filters;
public class MyActionFilterAttribute : ActionFilterAttribute //IResultFilter, IActionFilter
{
    public override void OnActionExecuting(ActionExecutingContext context) 
    {
        Console.WriteLine($"Executing {context.ActionDescriptor.DisplayName}" );
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine($"Executed {context.Result.ToString()}" );
    }
}