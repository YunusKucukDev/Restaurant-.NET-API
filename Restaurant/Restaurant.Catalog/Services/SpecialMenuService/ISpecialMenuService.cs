using Restaurant.Catalog.Dtos.SpecialMenuDtos;

namespace Restaurant.Catalog.Services.SpecialMenuService
{
    public interface ISpecialMenuService
    {
        Task<List<ResultSpecialMenuDto>> GetSpecialMenusAsync();
        Task<GetByIdSpecialMenuDto> GetByIdSpecialMenuAsync(string specialMenuId);
        Task CreateSpecialMenuAsync(CreateSpecialMenuDto createSpecialMenuDto);
        Task UpdateSpecialMenuAsync(UpdateSpecialMenuDto updateSpecialMenuDto);
        Task DeleteSpecialMenuAsync(string specialMenuId);
    }
}
