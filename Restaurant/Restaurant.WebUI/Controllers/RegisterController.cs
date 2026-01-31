using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.IdentityDtos.RegisterDtos;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly HttpClient _httpClient;
        public RegisterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
            {
               await _httpClient.PostAsJsonAsync("https://localhost:5001/api/Registers", createRegisterDto);
              return RedirectToAction("Index", "Login");
            }
            return View();



        }
    }
}
