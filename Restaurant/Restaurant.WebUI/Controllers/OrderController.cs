using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.OrderDtos;
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
            var values = await _orderService.GetByUserIdAsync(userId.Id);
            return View(values);
        }

       
        [HttpGet("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketService.GetBasket();
            if (basket == null || !basket.BasketItems.Any())
            {
                return RedirectToAction("Index", "Basket");
            }
            var total = basket.TotalPrice;

            decimal discount = basket.DiscountRate.HasValue ? (total * basket.DiscountRate.Value / 100) : 0;
            var discountedPrice = total - discount;
            var subTotalWithoutTax = discountedPrice / 1.1m;
            var tax = discountedPrice - subTotalWithoutTax;

            ViewBag.TotalPrice = total;          
            ViewBag.Discount = discount;          
            ViewBag.SubTotal = subTotalWithoutTax; 
            ViewBag.Tax = tax;                   
            ViewBag.FinalTotal = discountedPrice; 

            return View(new CreateOrderDto());
        }


        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout(CreateOrderDto dto)
        {
            // 1. Sepet bilgilerini getir
            var basket = await _basketService.GetBasket();

            // 2. Sepetteki ürünleri Items listesine map'le
            dto.Items = basket.BasketItems.Select(x => new OrderItemEntity
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = (int)x.Price,
                Quantity = x.Quantity
            }).ToList();

            // 3. Bilgileri set et
            dto.UserId = basket.UserId;
            dto.CreatedDate = DateTime.Now;

            // 4. Hesaplamalar
            decimal discount = basket.DiscountRate.HasValue ? (basket.TotalPrice * basket.DiscountRate.Value / 100) : 0;
            dto.TotalPrice = (int)((basket.TotalPrice - discount) * 1.10m);

            try
            {
                // 5. Siparişi oluştur (var result kısmını sildik çünkü metot void/Task dönüyor)
                await _orderService.CreateAsync(dto);

                // 6. Başarılıysa Ödeme sayfasına yönlendir
                return RedirectToAction("Index", "Payment");
            }
            catch (Exception ex)
            {
                // Bir hata oluşursa kullanıcıya bildir
                ModelState.AddModelError("", "Sipariş oluşturulurken bir hata oluştu: " + ex.Message);
                return View(dto);
            }
        }


        [HttpGet("Success")]
        public IActionResult Success()
        {
            _basketService.DeleteBasket("");
            return View();
        }




        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var values = await _orderService.GetByIdAsync(id);
            var singleOrder = values.FirstOrDefault();

            if (singleOrder == null)
            {
                return RedirectToAction("Index");
            }

            return View(singleOrder); // Listeyi değil, tek bir ResultOrderDto gönderiyoruz
        }
    }
}