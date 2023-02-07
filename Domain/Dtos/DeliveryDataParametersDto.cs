using Domain.Entities;

namespace Domain.Dtos
{
    public class DeliveryDataParametersDto
    {
        public List<Location>? LocationAtypicalDataOnLeft { get; set; }
        public List<Location>? LocationSubGroupTypicalData { get; set; }
        public List<Location>? LocationAtypicalDataOnRigth { get; set; }
    }
}
