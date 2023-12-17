using ServiceOrders.Models.DTO.Users;

namespace ServiceOrders.Models.Interfaces
{
    public interface IUsersRepository
    {
        public Task<List<UserResponse>> GetUsersAsync(string firstName, string lastName);
        public Task<UserResponse> GetUserAsync(string login);
        public Task<int> CreateUserAsync(CreateUserRequest request);
    }
}
