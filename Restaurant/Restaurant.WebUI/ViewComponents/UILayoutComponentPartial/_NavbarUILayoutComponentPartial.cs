using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.Branch1_InformationServices;
using Restaurant.WebUI.Services.Catalog.Branch2_InformationServices;
using System.Threading.Tasks;

namespace Restaurant.WebUI.ViewComponents.UILayoutComponentPartial
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {

        private readonly IBranch1_InformationService _branch1_InformationService;
        private readonly IBranch2_InformationService _branch2_InformationService;

        public _NavbarUILayoutComponentPartial(IBranch2_InformationService branch2_InformationService, IBranch1_InformationService branch1_InformationService)
        {
            _branch2_InformationService = branch2_InformationService;
            _branch1_InformationService = branch1_InformationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var branch1 = await _branch1_InformationService.GetAllBranch1_Information();
            var branch2 = await _branch2_InformationService.GetAllBranch2_Information();
            ViewBag.branch1Phone = branch1.FirstOrDefault()?.PhoneNumber;
            ViewBag.branch2Phone = branch2.FirstOrDefault()?.PhoneNumber;
            return View();
        }
    }
}
