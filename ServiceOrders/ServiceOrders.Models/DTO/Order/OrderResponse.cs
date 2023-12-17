using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrders.Models.DTO.Order
{
    public record OrderResponse(
        int OrderId,
        DateTime OrderDate
    );
}
