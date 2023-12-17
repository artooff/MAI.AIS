using ServiceOrders.Models.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrders.Models.Interfaces
{
    public interface IOrdersRepository
    {
        public Task<int> AddServiceToOrderAsync(AddServiceToOrderRequest request);
        public Task<OrderResponse> GetOrderForUserAsync(int userId);
    }
}
