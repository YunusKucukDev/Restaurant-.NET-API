using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Enum
{
    public enum OrderStatus
    {
        Pending,
        Paid,
        Cancelled,
        Shipped,
        Completed
    }
}
