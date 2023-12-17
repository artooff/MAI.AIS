using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceOrders.Models.DTO.Order;
using ServiceOrders.Models.Interfaces;

namespace ServiceOrders.OrdersService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddServiceToOrder([FromBody] AddServiceToOrderRequest addServiceToOrderRequest)
        {
            var orderId = await _ordersService.AddServiceToOrderAsync(addServiceToOrderRequest);
            return Ok(orderId);
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetOrderForUser(string login)
        {
            var order = await _ordersService.GetOrderForUserAsync(login);

            if (order != null)
            {
                return Ok(order);
            }

            return NotFound();
        }
    }
}
