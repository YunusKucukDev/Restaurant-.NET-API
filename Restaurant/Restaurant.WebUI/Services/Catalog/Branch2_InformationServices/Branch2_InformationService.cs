using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch2_Dtos;

namespace Restaurant.WebUI.Services.Catalog.Branch2_InformationServices
{
    public class Branch2_InformationService : IBranch2_InformationService
    {
        private readonly HttpClient _httpClient;

        public Branch2_InformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBranch2_Information(CreateBranch2_Dto createBranc2_Dto)
        {
            await _httpClient.PostAsJsonAsync<CreateBranch2_Dto>("http://localhost:7000/api/Branch2_Information", createBranc2_Dto);
        }

        public async Task DeleteBranch2_Information(string id)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/Branch2_Information/{id}");
        }

        public async Task<List<ResultBranch2_Dto>> GetAllBranch2_Information()
        {
            var responseMessage =_httpClient.GetAsync("http://localhost:7000/api/Branch2_Information");
            if (responseMessage.Result.IsSuccessStatusCode)
            {
                var result = await responseMessage.Result.Content.ReadFromJsonAsync<List<ResultBranch2_Dto>>();
                return result;
            }
            return null;
        }

        public async Task<UpdateBranch2_Dto> GetByIdBranch2_InformationById(string id)
        {
            var responseMessage = _httpClient.GetAsync("http://localhost:7000/api/Branch2_Information/" + id);
            if (responseMessage.Result.IsSuccessStatusCode)
            {
                var result = await responseMessage.Result.Content.ReadFromJsonAsync<UpdateBranch2_Dto>();
                return result;
            }
            return null;
        }

        public async Task UpdateBranch2_Information(UpdateBranch2_Dto updateBranc2_Dto)
        {
             await _httpClient.PutAsJsonAsync<UpdateBranch2_Dto>("http://localhost:7000/api/Branch2_Information", updateBranc2_Dto);
        }
    }
}
