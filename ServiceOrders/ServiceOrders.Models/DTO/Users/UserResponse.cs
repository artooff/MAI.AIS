namespace ServiceOrders.Models.DTO.Users
{
    public record UserResponse(
        int Id,
        string Login,
        string FirstName,
        string LastName,
        string Email,
        string Treatment
    );
}
