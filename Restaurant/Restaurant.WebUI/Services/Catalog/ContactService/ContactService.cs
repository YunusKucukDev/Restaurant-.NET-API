using Restaurant.DtoLayer.CatalogDtos.ContactDtos;

namespace Restaurant.WebUI.Services.Catalog.ContactService
{
    public class ContactService : IContactService
    {

        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContact(CreateContactDto dto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/Contacts", dto);
        }

        public async Task<List<ResultContactDto>> GetAllContacts()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("http://localhost:7000/api/Contacts");
            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContact(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<GetByIdContactDto>($"http://localhost:7000/api/Contacts/{id}");
            return values;
        }

        public async Task<GetByUserIdContactDto> GetByUserIdContact(string userid)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:7000/api/Contacts/{userid}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetByUserIdContactDto>();
                }

                // API 404 veya 500 dönerse burası çalışır
                return new GetByUserIdContactDto(); // Boş model dön ki sayfa patlamasın
            }
            catch (Exception)
            {
                return new GetByUserIdContactDto();
            }
        }
    }
}
