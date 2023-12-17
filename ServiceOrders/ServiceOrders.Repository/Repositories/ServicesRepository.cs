using Microsoft.EntityFrameworkCore;
using ServiceOrders.Models.DTO.Service;
using ServiceOrders.Models.DTO.ServiceInOrder;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.Models.Service;

namespace ServiceOrders.Repository.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly ServiceOrdersDbContext _dbContext;

        public ServicesRepository(ServiceOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateServiceAsync(CreateServiceRequest request)
        {
            var service = new Service
            {
                Title = request.Title,
                Category = request.Category,
                Description = request.Description,
                Price = request.Price
            };

            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();

            return service.Id;
        }

        public async Task<List<ServiceResponse>> GetServicesAsync()
        {
            var services = await _dbContext.Services.ToListAsync();

            return services.Select(service => new ServiceResponse
            (
                service.Id,
                service.Title,
                service.Category,
                service.Description,
                service.Price
            )).ToList();
        }

        public async Task<List<ServiceInOrderResponse>> GetServicesByOrderAsync(int orderId)
        {
            var servicesInOrder = await _dbContext.ServicesInOrders
                .Where(service => service.OrderId == orderId)
                .ToListAsync();

            if (servicesInOrder.Count == 0)
                return null;

            var allServices = await _dbContext.Services.ToListAsync();

            var servicesInOrderResponse = servicesInOrder
                .Select(serviceInOrder =>
                {
                    var service = allServices
                    .FirstOrDefault(service => service.Id == serviceInOrder.ServiceId);
                    return new ServiceInOrderResponse
                    (
                        service.Id,
                        service.Title,
                        service.Price
                    );
                })
                .ToList();

            return servicesInOrderResponse;
        }

    }
}

