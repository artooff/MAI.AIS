using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceOrders.Models.DTO.Service;
using ServiceOrders.Models.Interfaces;

namespace ServiceOrders.ServicesService.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceRequest request)
        {
            var serviceId = await _servicesService.CreateServiceAsync(request);
            return Ok(serviceId);
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _servicesService.GetServicesAsync();
            return Ok(services);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetServicesByOrder(int orderId)
        {
            var services = await _servicesService.GetServicesByOrderAsync(orderId);
            if(services == null)
                return NotFound();
            return Ok(services);
        }
    }
}
