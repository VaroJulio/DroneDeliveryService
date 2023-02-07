using DroneDeliveryService.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DroneDeliveryService.Requests
{
    public class DeliveryRequest
    {
        [Required]
        [DataType(DataType.Upload)]
        [FileNameValidation("deliveries")]
        [FileExtensionValidation(".txt")]
        [FileContentValidation]
        public IFormFile? DeliveriesFile { get; set; }
    }
}
