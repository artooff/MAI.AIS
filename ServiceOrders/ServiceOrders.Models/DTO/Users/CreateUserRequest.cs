using System.ComponentModel.DataAnnotations;

namespace ServiceOrders.Models.DTO.Users
{
    public record CreateUserRequest(
        string Login,
        string Password,
        string FirstName,
        string LastName,
        string Email,
        [EnumDataType(typeof(UserTreatment), ErrorMessage = "Invalid value for Treatment. Valid values are: Mr, Mrs")]
        string Treatment
    );
}
