using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Update
{
    public class CancelOrderDto
    {
        public int OrderId { get; set; }
        public string? Reason { get; set; }
    }
}
