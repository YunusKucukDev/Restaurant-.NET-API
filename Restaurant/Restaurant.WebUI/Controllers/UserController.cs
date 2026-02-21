using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }



    }
}
