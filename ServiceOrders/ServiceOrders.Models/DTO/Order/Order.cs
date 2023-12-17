using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceOrders.Models.Order
{
    public class Order 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
