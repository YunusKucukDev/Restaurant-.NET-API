using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch2_Dtos;

namespace Restaurant.WebUI.Services.Catalog.Branch2_InformationServices
{
    public interface IBranch2_InformationService
    {
        Task<List<ResultBranch2_Dto>> GetAllBranch2_Information();
        Task<GetByIdBranch2_Dto> GetByIdBranch2_InformationById(string id);
        Task CreateBranch2_Information(CreateBranch2_Dto createBranc2_Dto);
        Task UpdateBranch2_Information(UpdateBranch2_Dto updateBranc2_Dto);
        Task DeleteBranch2_Information(string id);
    }
}
