namespace ServiceOrders.Models.DTO.Service
{
    public record CreateServiceRequest(
        string Title,
        string Category,
        string Description,
        decimal Price
    );
}
