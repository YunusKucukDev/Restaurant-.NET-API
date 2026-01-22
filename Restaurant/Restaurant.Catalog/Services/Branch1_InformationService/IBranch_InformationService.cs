using Restaurant.Catalog.Dtos.Branch1_Dtos;

namespace Restaurant.Catalog.Services.Branch1_InformationService
{
    public interface IBranch_InformationService
    {
        Task<List<ResultBranc1_Dto>> GetAllBranch1_Information();
        Task<GetByIdBranc1_Dto> GetByIdBranch1_InformationById(string id);
        Task CreateBranch1_Information(CreateBranc1_Dto createBranc1_Dto);
        Task UpdateBranch1_Information(UpdateBranc1_Dto updateBranc1_Dto);
        Task DeleteBranch1_Information(string id);

    }
}
