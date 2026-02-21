using Restaurant.Catalog.Dtos.ContactDtos;

namespace Restaurant.Catalog.Services.ContactService
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GEtAllContacts();
        Task<GetByIdContactDto> GetByIdContactDto(string id);
        Task<GetByUserIdContactDto> GetByUserIdContactDto(string userId);
        Task CreateContactDto(CreateContactDto dto);
    }
}
