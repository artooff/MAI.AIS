namespace ServiceOrders.Models.DTO.Service
{
    public record ServiceResponse(
        int Id,
        string Title,
        string Category,
        string Description,
        decimal Price
    );
}
