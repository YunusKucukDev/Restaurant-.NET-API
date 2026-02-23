using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.BookingDtos;
using Restaurant.WebUI.Services.Catalog.BookingService;
using Restaurant.WebUI.Services.Interfaces;


[Route("Booking")]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly IUserService _userService;
    public BookingController(IBookingService bookingService, IUserService userService)
    {
        _bookingService = bookingService;
        _userService = userService;
    }


    [HttpGet]
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var user = await _userService.GetUserInfo();
        var userId = user.Id;
        var bookings = await _bookingService.GetByUserIdBooking(userId);
        return View(bookings);
    }

    [HttpGet("CreateBooking")]
    public async Task<IActionResult> CreateBooking()
    {
       return View();
    }

    [HttpPost("CreateBooking")]
    public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
    {
       
        var user = await _userService.GetUserInfo();
        dto.UserId = user.Id;
        // 3. Veriyi servise gönder
        await _bookingService.CreateBooking(dto);

        return RedirectToAction("Index","Booking");
    }

}