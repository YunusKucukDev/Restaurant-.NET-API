using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.WebUI.Models;
using Restaurant.WebUI.Services.RapidAPICurrency;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {

        private readonly MoneyCurrencyService _moneyCurrencyService;

        public DashBoardController(MoneyCurrencyService moneyCurrencyService)
        {
            _moneyCurrencyService = moneyCurrencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jsonData = await _moneyCurrencyService.GetCurrency();
            var result = JsonConvert.DeserializeObject<RapidCurrencyViewModel>(jsonData);

            // Sadece ekranda göstereceğimiz 4 birimi View'a model olarak gönderiyoruz
            return View(result.data);
        }
    }
}
