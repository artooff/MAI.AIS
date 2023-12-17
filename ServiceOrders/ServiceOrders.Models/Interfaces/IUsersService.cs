using ServiceOrders.Models.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceOrders.Models.Interfaces
{
    public interface IUsersService
    {
        public Task<UserResponse?> GetUserByLoginAsync(string login);
        public Task<List<UserResponse>> GetUsersAsync(string firstName, string lastName);
        public Task<int> CreateUserAsync(CreateUserRequest createRequest);
    }
}
