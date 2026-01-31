using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.Branch1_InformationServices;

namespace Restaurant.WebUI.ViewComponents.FooterComponentPartial
{
    public class _Branc1InformationComponentPartial : ViewComponent
    {
        private readonly IBranch1_InformationService _branch1_InformationService;

        public _Branc1InformationComponentPartial(IBranch1_InformationService branch1_InformationService)
        {
            _branch1_InformationService = branch1_InformationService;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            var values = await _branch1_InformationService.GetAllBranch1_Information();
            return View(values);
        }
    }
}
