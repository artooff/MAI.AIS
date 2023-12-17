using ServiceOrders.Models.DTO.Service;
using ServiceOrders.Models.DTO.ServiceInOrder;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.Repository.Repositories;

namespace ServiceOrders.ServicesService.Services
{
    public class ServiceService : IServicesService
    {
        private readonly IServicesRepository _servicesRepository;

        public ServiceService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public async Task<int> CreateServiceAsync(CreateServiceRequest request)
        {
            return await _servicesRepository.CreateServiceAsync(request);
        }

        public async Task<List<ServiceResponse>> GetServicesAsync()
        {
            return await _servicesRepository.GetServicesAsync();
        }

        public async Task<List<ServiceInOrderResponse>> GetServicesByOrderAsync(int orderId)
        {
            return await _servicesRepository.GetServicesByOrderAsync(orderId);
        }
    }
}
