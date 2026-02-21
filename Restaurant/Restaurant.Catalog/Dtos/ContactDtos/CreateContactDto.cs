namespace Restaurant.Catalog.Dtos.ContactDtos
{
    public class CreateContactDto
    {
       
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string? Subject { get; set; }
        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}
