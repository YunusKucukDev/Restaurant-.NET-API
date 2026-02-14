using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.OrderDtos.Create;
using Restaurant.DtoLayer.OrderDtos.Result;
using Restaurant.WebUI.Services.Basket;
using Restaurant.WebUI.Services.Interfaces;
using Restaurant.WebUI.Services.Order;
using System.Security.Claims;

namespace Restaurant.WebUI.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IBasketService basketService, IUserService userService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _userService = userService;
        }


        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var userId = await _userService.GetUserInfo();
            var values = await _orderService.GetOrdersByUserIdAsync(userId.Id);
            return View(values);
        }

        // Sipariş tamamlama sayfası (Adres bilgilerinin girildiği yer)
        [HttpGet("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketService.GetBasket();
            if (basket == null || !basket.BasketItems.Any())
            {
                return RedirectToAction("Index", "Basket");
            }

            // 1. Menü Fiyatı (KDV Dahil Ham Toplam)
            var total = basket.TotalPrice;

            // 2. İndirim Tutarı
            decimal discount = basket.DiscountRate.HasValue ? (total * basket.DiscountRate.Value / 100) : 0;

            // 3. İndirimli Fiyat (KDV Dahil)
            var discountedPrice = total - discount;

            // 4. KDV'siz Tutar (Ara Toplam)
            // Örn: 110 TL / 1.1 = 100 TL
            var subTotalWithoutTax = discountedPrice / 1.1m;

            // 5. KDV Tutarı (Sadece vergi kısmı)
            // Örn: 110 TL - 100 TL = 10 TL
            var tax = discountedPrice - subTotalWithoutTax;

            // ViewBag değerleri
            ViewBag.TotalPrice = total;           // Ham Menü Toplamı
            ViewBag.Discount = discount;          // Yapılan İndirim
            ViewBag.SubTotal = subTotalWithoutTax; // Ara Toplam (KDV Hariç)
            ViewBag.Tax = tax;                    // Vergi
            ViewBag.FinalTotal = discountedPrice; // Genel Toplam (Ödenecek)

            return View(new CreateOrderDto());
        }


        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout(CreateOrderDto dto)
        {
            var basket = await _basketService.GetBasket();
            dto.OrderDetails = basket.BasketItems.Select(x => new OrderDetailDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = (int)x.Price,
                ProductAmount = x.Quantity,
                TotalPrice = (int)(x.Price * x.Quantity)
            }).ToList();

            
            dto.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0";
            dto.OrderDate = DateTime.Now;

            
            decimal discount = basket.DiscountRate.HasValue ? (basket.TotalPrice * basket.DiscountRate.Value / 100) : 0;
            dto.TotalPrice = (int)((basket.TotalPrice - discount) * 1.10m);

           
            var result = await _orderService.CreateOrderAsync(dto);

            if (result)
            {
               
                await _basketService.RemoveBasketItem("all"); 
                return RedirectToAction("Success");
            }

            ModelState.AddModelError("", "Sipariş işlenirken bir hata oluştu.");
            return View(dto);
        }

        
        [HttpGet("Success")]
        public IActionResult Success()
        {
            return View();
        }

      
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}