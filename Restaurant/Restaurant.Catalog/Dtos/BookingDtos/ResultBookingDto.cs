using Restaurant.Catalog.Entities;

namespace Restaurant.Catalog.Dtos.BookingDtos
{
    public class ResultBookingDto
    {
        public string BookingId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
