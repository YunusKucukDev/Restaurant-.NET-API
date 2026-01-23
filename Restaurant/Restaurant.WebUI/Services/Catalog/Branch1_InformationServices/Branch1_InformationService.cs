
using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch1_Dtos;
using System.Net.Http.Json;

namespace Restaurant.WebUI.Services.Catalog.Branch1_InformationServices
{
    public class Branch1_InformationService : IBranch1_InformationService
    {

        private readonly HttpClient _httpClient;

        public Branch1_InformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBranch1_Information(CreateBranch1_Dto createBranc1_Dto)
        {
            await _httpClient.PostAsJsonAsync<CreateBranch1_Dto>("http://localhost:7000/api/Branch1_Information", createBranc1_Dto); 
        }

        public async Task DeleteBranch1_Information(string id)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/Branch1_Information/{id}");
        }

        public async Task<List<ResultBranch1_Dto>> GetAllBranch1_Information()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7000/api/Branch1_Information");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultBranch1_Dto>>();
            return values;

        }

        public async Task<UpdateBranch1_Dto> GetByIdBranch1_InformationById(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7000/api/Branch1_Information/" + id);
            var values = await responseMessage.Content
                .ReadFromJsonAsync<UpdateBranch1_Dto>();
            return values;
        }

        public async Task UpdateBranch1_Information(UpdateBranch1_Dto updateBranc1_Dto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBranch1_Dto>("http://localhost:7000/api/Branch1_Information", updateBranc1_Dto);
        }
    }
}
