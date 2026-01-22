using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch1_Dtos;

namespace Restaurant.WebUI.Services.Catalog.Branch1_InformationServices
{
    public interface IBranch1_InformationService
    {
        Task<List<ResultBranch1_Dto>> GetAllBranch1_Information();
        Task<GetByIdBranch1_Dto> GetByIdBranch1_InformationById(string id);
        Task CreateBranch1_Information(CreateBranch1_Dto createBranc1_Dto);
        Task UpdateBranch1_Information(UpdateBranch1_Dto updateBranc1_Dto);
        Task DeleteBranch1_Information(string id);
    }
}
