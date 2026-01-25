using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.SpecialMenuService;
using System.Threading.Tasks;

namespace Restaurant.WebUI.ViewComponents.MenuComponnetPartial
{
    public class _SpecialMenuComponentPartial : ViewComponent
    {

        private readonly ISpecialMenuService _specialMenuService;

        public _SpecialMenuComponentPartial(ISpecialMenuService specialMenuService)
        {
            _specialMenuService = specialMenuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await  _specialMenuService.GetAllspecialMenus();
            return View(values);
        }
    }
}
