using ServiceOrders.Models.DTO.Users;
using ServiceOrders.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceOrders.UsersService
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<int> CreateUserAsync(CreateUserRequest createRequest)
        {
            //if (!Enum.TryParse<UserTreatment>(createRequest.Treatment, out var userTreatment))
            //{
            //    var validValues = string.Join(", ", Enum.GetValues<UserTreatment>());
            //    throw new ArgumentException($"Invalid value for Treatment: {createRequest.Treatment}. Valid values are: {validValues}");
            //}

            return await _usersRepository.CreateUserAsync(createRequest);
        }

        public async Task<UserResponse?> GetUserByLoginAsync(string login)
        {
            return await _usersRepository.GetUserAsync(login);
        }

        public async Task<List<UserResponse>> GetUsersAsync(string firstName, string lastName)
        {
            return await _usersRepository.GetUsersAsync(firstName, lastName);
        }
    }
}
