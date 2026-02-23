using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.BookingDtos;
using Restaurant.Catalog.Services.BookingService;

namespace Restaurant.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            var values = await _bookingService.GetAllBooking();
            return Ok(values);
        }

        [HttpGet("GetBookingCount")]
        public async Task<IActionResult> GetBookingCount()
        {
            var values = await _bookingService.GetBookingCount();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBooking(string id)
        {
            var value = await _bookingService.GetByIdBooking(id);
            return Ok(value);
        }

        [HttpGet("GetByUserIdBooking/{userid}")]
        public async Task<IActionResult> GetByUserIdBooking(string userid)
        {
            var value = await _bookingService.GetByUserIdBooking(userid);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBooking(dto);
            return Ok("başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBooking(id);
            return Ok("başarılı");

        }
    }
}
