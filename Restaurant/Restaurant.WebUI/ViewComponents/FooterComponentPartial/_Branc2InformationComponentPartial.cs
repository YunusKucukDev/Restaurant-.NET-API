using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.Branch1_InformationServices;
using Restaurant.WebUI.Services.Catalog.Branch2_InformationServices;

namespace Restaurant.WebUI.ViewComponents.FooterComponentPartial
{
    public class _Branc2InformationComponentPartial : ViewComponent
    {
        private readonly IBranch2_InformationService _branch2_InformationService;

        public _Branc2InformationComponentPartial(IBranch2_InformationService branch2_InformationService)
        {
            _branch2_InformationService = branch2_InformationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _branch2_InformationService.GetAllBranch2_Information();
            return View(values);
        }
    }
}
