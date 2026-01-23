

using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Aboutservice;

namespace Restaurant.WebUI.Services.Catalog.AboutService
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAbouts();
        Task<UpdateAboutDto> GetByIdAbotDto(string id);
        Task UpdateAboutDto(UpdateAboutDto updateAboutDto);
        
    }
}
