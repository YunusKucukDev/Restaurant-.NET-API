using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.Branch1_Dtos;
using Restaurant.Catalog.Services.Branch1_InformationService;

namespace Restaurant.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Branch1_InformationController : ControllerBase
    {

        private readonly IBranch_InformationService _branchInformationService;

        public Branch1_InformationController(IBranch_InformationService branchInformationService)
        {
            _branchInformationService = branchInformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranch1_Information()
        {
            var values = await _branchInformationService.GetAllBranch1_Information();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBranch1_Information(string id)
        {
            var value = await _branchInformationService.GetByIdBranch1_InformationById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch1_Information(CreateBranc1_Dto createBranc1_Dto)
        {
            await _branchInformationService.CreateBranch1_Information(createBranc1_Dto);
            return Ok("Succesfull");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch1_Information(UpdateBranc1_Dto updateBranc1_Dto)
        {
            await _branchInformationService.UpdateBranch1_Information(updateBranc1_Dto);
            return Ok("Succesfull");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBranch1_Information(string id)
        {
            await _branchInformationService.DeleteBranch1_Information(id);
            return Ok("Succesfull");
        }


    }
}
