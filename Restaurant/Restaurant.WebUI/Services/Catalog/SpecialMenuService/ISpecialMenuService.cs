using Restaurant.DtoLayer.CatalogDtos.MenuDtos.SpecialMenuDtos;

namespace Restaurant.WebUI.Services.Catalog.SpecialMenuService
{
    public interface ISpecialMenuService
    {
        Task<List<ResultSpecialMenuDtos>> GetAllspecialMenus();
        Task<UpdateSpecialMenuDtos> GetByIdSpecialMenu(string id);
        Task CreateSpecialMenu(CreateSpecialMenuDtos createSpecialMenuDtos);
        Task DeleteSpecialMenu(string id);
        Task UpdateSpecialMenu(UpdateSpecialMenuDtos updateSpecialMenuDtos);
        Task<int> GetSpecialMenuCount();
    }
}
