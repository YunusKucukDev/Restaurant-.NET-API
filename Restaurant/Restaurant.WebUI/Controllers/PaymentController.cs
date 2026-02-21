using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Basket;
using Restaurant.WebUI.Services.Interfaces;
using Restaurant.WebUI.Services.PaymentService;

namespace Restaurant.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;

        public PaymentController(IPaymentService paymentService, IBasketService basketService, IUserService userService)
        {
            _paymentService = paymentService;
            _basketService = basketService;
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Index(string orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> SelectPaymentMethod(string orderId, bool choice)
        {
            var result = await _paymentService.DefinePaymentChoiceAsync(orderId, choice);

            if (choice)
            {
                // Online ödeme seçildiyse ödeme banka simülasyonuna veya formuna gönder
                return RedirectToAction("CreditCardPayment", new { orderId = orderId });
            }
            else
            {
                // Kapıda ödeme seçildiyse direkt bitir
                return RedirectToAction("CashPaymentSuccess", new { orderId = orderId });
            }
        }

        // Kredi Kartı Bilgileri Sayfası
        [HttpGet]
        public IActionResult CreditCardPayment(string orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
            // return RedirectToAction("Success","Order");
        }

        
        [HttpGet("CashPaymentSuccess")]
        public async Task<IActionResult> CashPaymentSuccess(string orderId)
        {
            
            var user = await _userService.GetUserInfo();
            await _basketService.DeleteBasket(user.Id);

            ViewBag.OrderId = orderId;
            return View();
        }

       
        [HttpPost]
        [Route("Payment/Success/")]
        public async Task<IActionResult> Success(string orderId)
        {
            // 1. Kullanıcı bilgilerini al
            var user = await _userService.GetUserInfo();

            // 2. Sepeti boşalt
            await _basketService.DeleteBasket(user.Id);

            ViewBag.OrderId = orderId;
            return View();
        }
    }
}