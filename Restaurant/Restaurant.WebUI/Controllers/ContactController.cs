using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.ContactDtos;
using Restaurant.WebUI.Services.Catalog.ContactService;
using Restaurant.WebUI.Services.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;
        private readonly IUserService _userService;

        public ContactController(IContactService contactService, IUserService userService)
        {
            _contactService = contactService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();
            var contacts = await _contactService.GetByUserIdContact(user.Id);
            return View(contacts);
        }


        [HttpGet]
        public IActionResult CreateContact()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult>  CreateContact(CreateContactDto dto)
        {
            await _contactService.CreateContact(dto);
            return RedirectToAction("Index","Contact");
        }
    }
}
