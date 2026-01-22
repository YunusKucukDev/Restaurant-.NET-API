using Restaurant.Catalog.Dtos.Branch2_Dtos;

namespace Restaurant.Catalog.Services.Branch2_InformationService
{
    public interface IBranch2_InformationService
    {
        Task<List<ResultBranc2_Dto>> GetAllBranch2_Information();
        Task<GetByIdBranc2_Dto> GetByIdBranch2_Information(string id);
        Task CreateBranch2_Information(CreateBranc2_Dto createBranc2_Dto);
        Task UpdateBranch2_Information(UpdateBranc2_Dto updateBranc2_Dto);
        Task DeleteBranch2_Information(string id);
        
    }
}
