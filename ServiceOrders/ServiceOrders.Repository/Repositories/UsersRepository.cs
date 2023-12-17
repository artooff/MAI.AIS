using Microsoft.EntityFrameworkCore;
using ServiceOrders.Models.DTO.Users;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrders.Repository.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ServiceOrdersDbContext _dbContext;

        public UsersRepository(ServiceOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateUserAsync(CreateUserRequest request)
        {
            var user = new User
            {
                Login = request.Login,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Treatment = (UserTreatment)Enum.Parse(typeof(UserTreatment), request.Treatment)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserResponse?> GetUserAsync(string login)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user != null
                ? new UserResponse(
                    user.Id,
                    user.Login,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    Enum.GetName(user.Treatment.GetType(), user.Treatment)
                )
                : null;
        }

        public async Task<List<UserResponse>> GetUsersAsync(string firstName, string lastName)
        {
            var users = await _dbContext.Users
                .Where(u => EF.Functions.Like(u.FirstName, $"{firstName}%") && EF.Functions.Like(u.LastName, $"{lastName}%"))
                .ToListAsync();

            return users.Select(user => new UserResponse(
                    user.Id,
                    user.Login,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    Enum.GetName(user.Treatment.GetType(), user.Treatment)
                ))
                .ToList();
        }
    }
}
