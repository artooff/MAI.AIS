using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServiceOrders.Models.DTO.Users;

namespace ServiceOrders.OrdersService.Clients
{
    public class UsersClient
    {
        private readonly HttpClient _httpClient;

        public UsersClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_httpClient.BaseAddress = new Uri("http://localhost:5001");
        }

        public async Task<UserResponse> GetUserByLoginAsync(string login)
        {
            var escapedLogin = Uri.EscapeDataString(login);

            var response = await _httpClient.GetAsync($"api/users/{escapedLogin}");

            if (response.IsSuccessStatusCode)
            {
                var resp =  await response.Content.ReadFromJsonAsync<UserResponse>();
                return resp;
            }

            return null;
        }
    }
}
