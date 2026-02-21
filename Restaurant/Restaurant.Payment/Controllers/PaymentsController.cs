using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Payment.Dtos;
using Restaurant.Payment.Services;

namespace Restaurant.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var values = await _paymentService.GetAllPayments();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var value = await _paymentService.GetPaymentById(id);
            return Ok(value);
        }

        [HttpGet("GetByOrderId/{orderId}")]
        public async Task<IActionResult> GetPaymentByOrderId(int orderId)
        {
            var value = await _paymentService.GetPaymentByOrderId(orderId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            await _paymentService.CreatePayment(createPaymentDto);
            return Ok("Ödeme kaydı başarıyla oluşturuldu.");
        }

        // WebUI tarafındaki DefinePaymentChoiceAsync metodunun çağırdığı yer burasıdır.
        [HttpPost("DefineChoice")]
        public async Task<IActionResult> DefineChoice(int orderId, bool choice)
        {
            // Servis içindeki parametre sırasına ve ismine dikkat ederek çağırıyoruz
            await _paymentService.DefinePaymentOption(orderId, choice);
            return Ok("Ödeme tercihi güncellendi.");
        }
    }
}