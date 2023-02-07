using Application.Interfaces;
using DroneDeliveryService.Filters;
using DroneDeliveryService.Requests;
using DroneDeliveryService.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DroneDeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        IDeliveriesService _deliveriesService;
        public DeliveriesController(IDeliveriesService deliveriesService) 
        {
            _deliveriesService = deliveriesService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(FileContentResult))]
        [ProducesResponseType(400, Type = typeof(DeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(DeliveryResponse))]
        [ServiceFilter(typeof(ValidateFileFilter))]
        [ServiceFilter(typeof(ProcessDeliveriesFilter))]
        public async Task<IActionResult> ProcessDeliveries([FromForm] DeliveryRequest DeliveryRequest)
        {
            var deliveryData = await _deliveriesService.CalculateDeliveries(DeliveryRequest.DeliveriesFile);
            var memoryStream = await _deliveriesService.ReturnDeliveriesAsMemoryStream(deliveryData);
            return File(memoryStream.ToArray(), "text/plain", "deliveries_out.txt");
        }
    }
}
