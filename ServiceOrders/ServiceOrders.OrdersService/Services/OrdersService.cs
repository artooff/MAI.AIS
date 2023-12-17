using ServiceOrders.Models.DTO.Order;
using ServiceOrders.Models.DTO.ServiceInOrder;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.OrdersService.Clients;

namespace ServiceOrders.OrdersService.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly UsersClient _usersClient;
        private readonly ServicesClient _servicesClient;

        public OrdersService(IOrdersRepository ordersRepository, UsersClient usersClient, ServicesClient servicesClient)
        {
            _ordersRepository = ordersRepository;
            _usersClient = usersClient;
            _servicesClient = servicesClient;
        }

        public async Task<int> AddServiceToOrderAsync(AddServiceToOrderRequest request)
        {
            return await _ordersRepository.AddServiceToOrderAsync(request);
        }

        public async Task<OrderWithServicesResponse> GetOrderForUserAsync(string login)
        {
            var user = await _usersClient.GetUserByLoginAsync(login);
            if (user == null)
                return null;

            var order = await _ordersRepository.GetOrderForUserAsync(user.Id);
            if (order == null)
                return null;

            var servicesInOrder = await _servicesClient.GetServicesByOrderAsync(order.OrderId);
            if (servicesInOrder == null)
                servicesInOrder = new List<ServiceInOrderResponse>();

            var response = new OrderWithServicesResponse
            (
                 order.OrderId,
                 user.Login,
                 order.OrderDate,
                 servicesInOrder
            );

            return response;
        }
    }
}
