using ServiceOrders.Models.DTO.Service;
using ServiceOrders.Models.DTO.ServiceInOrder;

namespace ServiceOrders.Models.Interfaces
{
    public interface IServicesRepository
    {
        public Task<int> CreateServiceAsync(CreateServiceRequest request);
        public Task<List<ServiceResponse>> GetServicesAsync();
        public Task<List<ServiceInOrderResponse>> GetServicesByOrderAsync(int orderId);
    }
}
