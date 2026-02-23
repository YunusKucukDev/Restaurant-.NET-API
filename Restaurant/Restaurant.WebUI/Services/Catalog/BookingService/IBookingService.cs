using Restaurant.DtoLayer.CatalogDtos.BookingDtos;

namespace Restaurant.WebUI.Services.Catalog.BookingService
{
    public interface IBookingService
    {
        Task CreateBooking(CreateBookingDto dto);
        Task<List<ResultBookingDto>> GetAllBooking();
        Task DeleteBooking(string id);
        Task<ResultBookingDto> GetByIdBooking(string id);
        Task<ResultBookingDto> GetByUserIdBooking(string userid);
        Task<int>  GetBookingCount();
    }
}
