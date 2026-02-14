using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Result
{
    public class OrderItemDto
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
