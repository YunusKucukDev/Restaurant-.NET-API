using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Result
{
    public class OrderDetailDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; } // decimal -> double
        public int ProductAmount { get; set; }
        public int TotalPrice { get; set; } // decimal -> double
    }
}
