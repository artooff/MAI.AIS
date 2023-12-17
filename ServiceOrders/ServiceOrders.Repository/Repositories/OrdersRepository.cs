using Microsoft.EntityFrameworkCore;
using ServiceOrders.Models.DTO.Order;
using ServiceOrders.Models.DTO.ServiceInOrder;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.Models.Order;

namespace ServiceOrders.Repository.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ServiceOrdersDbContext _dbContext;

        public OrdersRepository(ServiceOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddServiceToOrderAsync(AddServiceToOrderRequest request)
        {
            var order = await _dbContext.Orders
                .Where(o => o.UserId == request.UserId)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                order = new Order
                {
                    UserId = request.UserId,
                    OrderDate = request.OrderDate,
                };

                await _dbContext.Orders.AddAsync(order);
            }

            var serviceInOrder = new ServiceInOrder
            {
                ServiceId = request.ServiceId,
                OrderId = order.Id
            };
            await _dbContext.ServicesInOrders.AddAsync(serviceInOrder);
            await _dbContext.SaveChangesAsync();

            return order.Id;
        }

        public async Task<OrderResponse> GetOrderForUserAsync(int userId)
        {
            var order = await _dbContext.Orders
                .Where(o => o.UserId == userId)
                .FirstOrDefaultAsync();

            if (order == null)
                return null;

            var response = new OrderResponse(
                order.UserId,
                order.OrderDate
                );

            return response;
        }
    }
}
