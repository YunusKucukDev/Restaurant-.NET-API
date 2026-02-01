using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.DiscountCoupondtos;
using Restaurant.WebUI.Services.DiscountCoupon;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Discount")]
    public class DiscountController : Controller
    {

        private readonly IDiscountcouponService _discountService;

        public DiscountController(IDiscountcouponService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _discountService.GetAllDiscountsCoupons();
            return View(values);
        }

        [HttpGet("GetByIdDiscountCoupon/{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var values = await _discountService.GetDiscountCouponById(id);
            return View(values);
        }

        [HttpGet]
        [Route("CreateDiscountCoupon")]
        public IActionResult CreateDiscountCoupon()
        {
            return View(new CreateDiscountCouponDto
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            });
        }

        [HttpPost]
        [Route("CreateDiscountCoupon")]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _discountService.CreateDiscountCoupon(createDiscountCouponDto);
            return RedirectToAction("Index", "Discount");
        }

        [HttpGet]
        [Route("UpdateDiscountCoupon/{id}")]
        public async Task<IActionResult> UpdateDiscountCoupon(int id)
        {
            var values = await _discountService.GetDiscountCouponById(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateDiscountCoupon/{id}")]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _discountService.UpdateDiscountCoupon(updateDiscountCouponDto);
            return RedirectToAction("Index", "Discount");
        }

        [HttpGet]
        [Route("DeleteDiscountCoupon/{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCoupon(id);
            return RedirectToAction("Index", "Discount");
        }


    }
}
