using DroneDeliveryService.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DroneDeliveryService.Filters
{
    public class ValidateFileFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            }
            else
            {
                IEnumerable<string> errors = new List<string>();

                foreach (var keyPair in context.ModelState)
                {
                    foreach (var error in keyPair.Value.Errors)
                    {
                        errors = errors.Append($"{keyPair.Key}: {error.ErrorMessage}");
                    }
                }

                var response = new DeliveryResponse() { Message = "Your request is not valid", Errors = errors.ToArray() };
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
