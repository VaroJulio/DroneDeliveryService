using DroneDeliveryService.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DroneDeliveryService.Filters
{
    public class ProcessDeliveriesFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            IEnumerable<string> errors = new List<string>();
            DeliveryResponse response = new DeliveryResponse();

            switch (context.Exception.GetType().Name)
            {
                case "BadHttpRequestException":
                    errors = errors.Append(context.Exception.Message);
                    response.Message = "Your request is not valid";
                    response.Errors = errors.ToArray();
                    context.Result = new BadRequestObjectResult(response);
                    break;
                case "BadRequestCustomException":
                    errors = errors.Append(context.Exception.Message);
                    response.Message = "Your request is not valid";
                    response.Errors = errors.ToArray();
                    context.Result = new BadRequestObjectResult(response);
                    break;
                default:
                    errors = errors.Append(context.Exception.Message);
                    response.Message = "An error occurs processing the deliveries.";
                    response.Errors = errors.ToArray();
                    context.Result = new InternalServerErrorResult(response);
                    break;
            }
        }
    }
}
