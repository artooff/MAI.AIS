using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrders.Models.DTO.ServiceInOrder
{
    public record ServiceInOrderResponse(
        int ServiceId,
        string ServiceName,
        decimal ServicePrice
    );
}
