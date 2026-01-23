using Restaurant.Catalog.Dtos.About;

namespace Restaurant.Catalog.Services.AboutService
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAbouts();
        Task<GetByIdAboutDto> GetByIdAbotDto(string id);
        Task UpdateAboutDto(UpdateAboutDto updateAboutDto);
        Task DeleteAboutDto(string id);
        Task CreateAboutDto(CreateAboutDto createAboutDto);
    }
}
