using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Trailz.Api.Filters
{
    public class ValidationActionFilter<T>(IValidator<T> validator) : IAsyncActionFilter
    {      
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var inputData = context.ActionArguments.OfType<T>()
               .FirstOrDefault(a => a?.GetType() == typeof(T));

            if (inputData is not null)
            {
                ValidationResult validationResult = await validator.ValidateAsync(inputData);
                if (!validationResult.IsValid)
                {
                    context.Result = new BadRequestObjectResult(validationResult.ToDictionary());
                    return;
                }
            }

            await next.Invoke();
        }
    }
}
