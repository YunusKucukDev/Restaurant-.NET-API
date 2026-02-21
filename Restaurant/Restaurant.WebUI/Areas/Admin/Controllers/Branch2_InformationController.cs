using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch2_Dtos;
using Restaurant.WebUI.Services.Catalog.Branch2_InformationServices;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Branch2_Information/")]
    public class Branch2_InformationController : Controller
    {
        private readonly IBranch2_InformationService _branch2_InformationService;

        public Branch2_InformationController(IBranch2_InformationService branch2_InformationService)
        {
            _branch2_InformationService = branch2_InformationService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _branch2_InformationService.GetAllBranch2_Information();
            return View(values);
        }


        [HttpGet]
        [Route("UpdateBranch2/{id}")]
        public async Task<IActionResult> UpdateBranch2(string id)
        {
            var values = await _branch2_InformationService.GetByIdBranch2_InformationById(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateBranch2/{id}")]
        public async Task<IActionResult> UpdateBranch2(UpdateBranch2_Dto dto)
        {
            await _branch2_InformationService.UpdateBranch2_Information(dto);
            return RedirectToAction("Index");
        }



    }
}
