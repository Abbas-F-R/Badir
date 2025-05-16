using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Badir.DtoValidator.BaseValidator;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var message = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .FirstOrDefault() ?? "حدث خطأ";

            context.Result = new BadRequestObjectResult(new { message });
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}