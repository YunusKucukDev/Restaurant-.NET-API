using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.IdentityDtos.LoginDtos;
using Restaurant.WebUI.Services.Interfaces;

namespace Restaurant.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "Home");
        }
    }
}

