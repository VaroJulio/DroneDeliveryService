using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IDeliveriesService
    {
        public Task<List<KeyValuePair<string, IEnumerable<Location>>>> CalculateDeliveries(IFormFile file);
        public Task<MemoryStream> ReturnDeliveriesAsMemoryStream(List<KeyValuePair<string, IEnumerable<Location>>> deliveries);
    }
}
