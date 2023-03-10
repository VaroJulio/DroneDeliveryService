using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DroneDeliveryService.Responses
{
    /// <summary>
    /// An <see cref="ObjectResult"/> that when executed will produce a Bad Request (400) response.
    /// </summary>
    [DefaultStatusCode(DefaultStatusCode)]
    public class InternalServerErrorResult : ObjectResult
    {

        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        /// <summary>
        /// Creates a new <see cref="InternalServerErrorResult"/> instance.
        /// </summary>
        /// <param name="error">Contains the errors to be returned to the client.</param>
        public InternalServerErrorResult([ActionResultObjectValue] object? error)
            : base(error)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
