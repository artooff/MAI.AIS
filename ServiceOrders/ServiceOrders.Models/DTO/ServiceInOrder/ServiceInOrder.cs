using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceOrders.Models.DTO.ServiceInOrder
{
    public class ServiceInOrder
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
    }
}
