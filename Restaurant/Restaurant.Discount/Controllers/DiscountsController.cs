using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Discount.Contex;
using Restaurant.Discount.Dtos;
using Restaurant.Discount.Entities;
using System.Threading.Tasks;


namespace Restaurant.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsCouponController : ControllerBase
    {
        private readonly DiscountDbContext _context;

        public DiscountsCouponController(DiscountDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DiscountCouponList()
        {
            var values = _context.Discounts.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscountCoupon(int id)
        {
            var value = _context.Discounts.Find(id);
            return Ok(value);
        }

        [HttpGet("GetDiscountCouponByDiscountCouponName/{name}")]
        public IActionResult GetDiscountCouponByDiscountCouponName(string name)
        {
            var value = _context.Discounts.FirstOrDefault(x => x.Code == name);

            if (value == null)
                return NotFound("İndirim kodu bulunamadı");

            return Ok(value);

        }

        [HttpGet("ActiveCoupons")]
        public IActionResult GetActiveCoupons()
        {
            var now = DateTime.Now;

            var values = _context.Discounts
                .Where(x =>
                    x.IsActive &&
                    x.StartDate <= now &&
                    x.EndDate >= now)
                .ToList();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountDto dto)
        {
            if (dto.EndDate <= dto.StartDate)
                return BadRequest("Bitiş tarihi başlangıç tarihinden sonra olmalıdır.");

            var coupon = new DiscountCoupon
            {
                Code = dto.Code,
                Rate = dto.Rate,
                StartDate = dto.StartDate == default
             ? DateTime.Today
             : dto.StartDate,
                EndDate = dto.EndDate == default
             ? DateTime.Today.AddDays(1)
             : dto.EndDate,
                IsActive = dto.IsActive
            };

            _context.Discounts.Add(coupon);
            await _context.SaveChangesAsync();

            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(DiscountCoupon discountCoupon)
        {
            _context.Discounts.Update(discountCoupon);
           await _context.SaveChangesAsync();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            var value = _context.Discounts.Find(id);
            if (value == null)
                return NotFound();

            _context.Discounts.Remove(value);
           await _context.SaveChangesAsync();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpGet("DiscountCouponListByProductId/{id}")]
        public IActionResult DiscountCouponListByProductId(int id)
        {
            var values = _context.Discounts
                                       .Where(x => x.DiscountId == id)
                                       .ToList();
            return Ok(values);
        }

        [HttpGet("ActiveDiscountCouponCount")]
        public IActionResult ActiveDiscountCouponCount()
        {
            var value = _context.Discounts.Count(x => x.IsActive == true);
            return Ok(value);
        }

        [HttpGet("PasiveDiscountCouponCount")]
        public IActionResult PasiveDiscountCouponCount()
        {
            var value =_context.Discounts.Count(x => x.IsActive == false);
            return Ok(value);
        }

        [HttpGet("TotalDiscountCouponCount")]
        public IActionResult TotalDiscountCouponCount()
        {
            var value = _context.Discounts.Count();
            return Ok(value);
        }
    }
}
