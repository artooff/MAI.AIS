using Microsoft.AspNetCore.Mvc;
using ServiceOrders.Models.DTO.Users;
using ServiceOrders.Models.Interfaces;

namespace ServiceOrders.UsersService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetUser(string login)
        {
            var userResponse = await _usersService.GetUserByLoginAsync(login);

            if (userResponse == null)
                return NotFound();

            return Ok(userResponse);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetUsers([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var usersResponse = await _usersService.GetUsersAsync(firstName, lastName);
            if (usersResponse == null)
                return NotFound();
            return Ok(usersResponse);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            try
            {
                var userId = await _usersService.CreateUserAsync(request);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
