using Restaurant.DtoLayer.CatalogDtos.ContactDtos;

namespace Restaurant.WebUI.Services.Catalog.ContactService
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContacts();
        Task<GetByIdContactDto> GetByIdContact(string id);
        Task<GetByUserIdContactDto> GetByUserIdContact(string userid);
        Task CreateContact(CreateContactDto dto);
    }
}
