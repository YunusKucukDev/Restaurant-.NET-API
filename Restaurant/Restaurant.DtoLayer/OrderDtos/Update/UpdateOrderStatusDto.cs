using Restaurant.DtoLayer.OrderDtos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Update
{
    public class UpdateOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
