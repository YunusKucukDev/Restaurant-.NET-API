using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.BookingService;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Booking")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var booking = await _bookingService.GetAllBooking();
            return View(booking);
        }

        [HttpGet("DeleteBooking/{id}")] 
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBooking(id);
            return RedirectToAction("Index", "Booking", new { area = "Admin" });
        }


    }
}
