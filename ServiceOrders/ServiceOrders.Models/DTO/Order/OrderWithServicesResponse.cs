using ServiceOrders.Models.DTO.ServiceInOrder;

namespace ServiceOrders.Models.DTO.Order
{
    public record OrderWithServicesResponse(
        int OrderId,
        string UserLogin,
        DateTime OrderDate,
        List<ServiceInOrderResponse> Services
    );
}
