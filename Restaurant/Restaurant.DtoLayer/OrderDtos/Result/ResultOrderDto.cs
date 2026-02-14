using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.OrderDtos.Result
{
    public class ResultOrderDto
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int TotalPrice { get; set; }

        // Eksik olan kısım burası:
        public DateTime OrderDate { get; set; }

        public string FullName { get; set; }
        // Varsa diğer alanlar...
    }
}
