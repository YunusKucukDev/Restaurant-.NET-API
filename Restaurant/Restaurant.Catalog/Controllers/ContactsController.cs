using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.ContactDtos;
using Restaurant.Catalog.Services.ContactService;
using System.Threading.Tasks;

namespace Restaurant.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var values = await _contactService.GEtAllContacts();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdContacts(string id)
        {
            var values = await _contactService.GetByIdContactDto(id);
            return Ok(values);
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUserIdContacts(string userid)
        {
            var values = await _contactService.GetByUserIdContactDto(userid);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
             await _contactService.CreateContactDto(dto);
            return Ok("Başarılı");
        }

    }
}
