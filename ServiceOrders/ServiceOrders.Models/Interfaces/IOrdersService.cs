using ServiceOrders.Models.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrders.Models.Interfaces
{
    public interface IOrdersService
    {
        Task<int> AddServiceToOrderAsync(AddServiceToOrderRequest request);
        Task<OrderWithServicesResponse> GetOrderForUserAsync(string login);
    }
}
