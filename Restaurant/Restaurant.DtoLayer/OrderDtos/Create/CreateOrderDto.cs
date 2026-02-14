using Restaurant.DtoLayer.OrderDtos.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Create
{
    public class CreateOrderDto
    {
        public string UserId { get; set; }
        public int TotalPrice { get; set; } 
        public DateTime OrderDate { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
