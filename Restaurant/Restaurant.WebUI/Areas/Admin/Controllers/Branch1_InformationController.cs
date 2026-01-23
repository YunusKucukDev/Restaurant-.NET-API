using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch1_Dtos;
using Restaurant.WebUI.Services.Catalog.Branch1_InformationServices;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Branch1_Information/")]
    public class Branch1_InformationController : Controller
    {
        private readonly IBranch1_InformationService _branch1_InformationService;

        public Branch1_InformationController(IBranch1_InformationService branch1_InformationService)
        {
            _branch1_InformationService = branch1_InformationService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _branch1_InformationService.GetAllBranch1_Information();
            return View(values);
        }

        [Route("GetByIdBranch1/{id}")]
        public async Task<IActionResult> GetByIdBranch1(string id)
        {
            var values = await _branch1_InformationService.GetByIdBranch1_InformationById(id);
            return View(values);
        }

        [Route("UpdateBranch1/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBranch1(string id)
        {
            var values = await _branch1_InformationService.GetByIdBranch1_InformationById(id);
            return View(values);
        }


        [Route("UpdateBranch1/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBranch1(UpdateBranch1_Dto dto)
        {
            await _branch1_InformationService.UpdateBranch1_Information(dto);
            return RedirectToAction("Index", "Branch1_Information");
        }

    }
}
