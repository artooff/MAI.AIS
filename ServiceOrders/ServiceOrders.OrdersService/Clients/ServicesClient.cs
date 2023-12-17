using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServiceOrders.Models.DTO.ServiceInOrder;

public class ServicesClient
{
    private readonly HttpClient _httpClient;

    public ServicesClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        //_httpClient.BaseAddress = new Uri("http://localhost:5002");
    }

    public async Task<List<ServiceInOrderResponse>> GetServicesByOrderAsync(int orderId)
    {
        var escapedOrderId = Uri.EscapeDataString(orderId.ToString());

        var response = await _httpClient.GetAsync($"api/services/{escapedOrderId}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<ServiceInOrderResponse>>();
        }

        return null;
    }
}
