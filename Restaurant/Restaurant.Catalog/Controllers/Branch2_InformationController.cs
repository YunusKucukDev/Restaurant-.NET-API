using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.Branch2_Dtos;
using Restaurant.Catalog.Services.Branch2_InformationService;

namespace Restaurant.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Branch2_InformationController : ControllerBase
    {

        private readonly IBranch2_InformationService _branch2InformationService;

        public Branch2_InformationController(IBranch2_InformationService branch2InformationService)
        {
            _branch2InformationService = branch2InformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranch2_Information()
        {
            var values = await _branch2InformationService.GetAllBranch2_Information();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBranch2_Information(string id)
        {
            var value = await _branch2InformationService.GetByIdBranch2_Information(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch2_Information(CreateBranc2_Dto createBranc2_Dto)
        {
            await _branch2InformationService.CreateBranch2_Information(createBranc2_Dto);
            return Ok("Succesfull");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch2_Information(UpdateBranc2_Dto updateBranc2_Dto)
        {
            await _branch2InformationService.UpdateBranch2_Information(updateBranc2_Dto);
            return Ok("Succesfull");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBranch2_Information(string id)
        {
            await _branch2InformationService.DeleteBranch2_Information(id);
            return Ok("Succesfull");
        }
    }
}
