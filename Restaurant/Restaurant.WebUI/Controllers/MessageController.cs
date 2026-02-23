using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Controllers
{
    public class MessageController : Controller
    {

        private readonly IUserService _userService;

        public MessageController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {       
            return View();
        }
    }
}
