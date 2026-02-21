
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.DtoLayer.CatalogDtos.IncomeDto;
using Restaurant.DtoLayer.CatalogDtos.OutcomeDto;
using Restaurant.WebUI.Services.Catalog.DailyReportService;
using Restaurant.WebUI.Services.Catalog.IncomeService;
using Restaurant.WebUI.Services.Catalog.OutcomeService;



namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Computation/")]
    public class ComputationController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IOutcomeService _outcomeService;
        private readonly IDailyReportService _dailyReportService;

        public ComputationController(IIncomeService incomeService, IOutcomeService outcomeService, IDailyReportService dailyReportService)
        {
            _incomeService = incomeService;
            _outcomeService = outcomeService;
            _dailyReportService = dailyReportService;
        }

        private void PopulateCompanies(string selectedValue = null)
        {
            var companies = new List<string> { "YemekSepeti", "Getir", "Trendyol", "Metropol", "Pluxee", "TokenFlex", "SetCard", "Multinet" };
            ViewBag.Companies = new SelectList(companies, selectedValue);
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(DateTime? selectedDate)
        {
            PopulateCompanies();
            
            DateTime filterDate = selectedDate?.Date ?? DateTime.Today.Date;
            var activeShift = HttpContext.Session.GetString("ActiveShift") ?? "Gunduz";

          
            var incomesByShift = await _incomeService.GetIncomesByShiftAsync(activeShift);
            var outcomesByShift = await _outcomeService.GetOutcomesByShiftAsync(activeShift);
            var allDailyReports = await _dailyReportService.GetDailyReportsByShiftAsync(activeShift);

           
            var incomes = incomesByShift
                .Where(x => x.Date.ToLocalTime().Date == filterDate.Date)
                .ToList();

            var outcomes = outcomesByShift
         .Where(x => x.Date.Date == filterDate.Date) 
         .ToList();

            
            ViewBag.TotalIncome = incomes.Sum(x => x.IncomeAmount);
            ViewBag.TotalOutcome = outcomes.Sum(x => x.OutcomeAmount);
            ViewBag.FinalIncome = (decimal)ViewBag.TotalIncome - (decimal)ViewBag.TotalOutcome;

           
            ViewBag.ActiveShift = activeShift;
            ViewBag.SelectedDate = filterDate.ToString("yyyy-MM-dd");
            ViewBag.RawDate = filterDate;
            ViewBag.IsReported = allDailyReports.Any(x => x.Date.ToLocalTime().Date == filterDate.Date);

            return View();
        }

        [HttpPost]
        [Route("CreateIncome")]
        public async Task<IActionResult> CreateIncome(CreateInComeDto dto)
        {
            ModelState.Remove("ShiftType");
            dto.Date = dto.Date.Date.AddHours(12);
            dto.ShiftType = HttpContext.Session.GetString("ActiveShift") ?? "Gunduz";
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { selectedDate = dto.Date.ToString("yyyy-MM-dd") });
            }
            if (!string.IsNullOrEmpty(dto.SelectedCompany))
            {
                decimal brutTutar = dto.IncomeAmount;
                decimal kesintiOrani = (dto.SelectedCompany == "YemekSepeti" ||
                                        dto.SelectedCompany == "Getir" ||
                                        dto.SelectedCompany == "Trendyol") ? 0.38m : 0.10m;

                decimal kesintiTutari = brutTutar * kesintiOrani;
                dto.IncomeAmount = brutTutar - kesintiTutari;
                dto.IncomeDescription = kesintiTutari;
            }
            await _incomeService.CreateIncomeDto(dto);
            return RedirectToAction("Index", new { selectedDate = dto.Date.ToString("yyyy-MM-dd") });
        }


        [HttpPost]
        [Route("CreateOutcome")]
        public async Task<IActionResult> CreateOutcome(CreateOutcomeDto dto)
        {
            ModelState.Remove("ShiftType");
            dto.Date = dto.Date.Date.AddHours(12);
            dto.ShiftType = HttpContext.Session.GetString("ActiveShift") ?? "Gunduz";

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { selectedDate = dto.Date.ToString("yyyy-MM-dd") });
            }

            await _outcomeService.CreateOutcomeDto(dto);
            return RedirectToAction("Index", new { selectedDate = dto.Date.ToString("yyyy-MM-dd") });
        }


        [Route("DeleteIncome")]
        [HttpDelete]
        public async Task<IActionResult> DeleteIncome(string id, DateTime selectedDate)
        {
            await _incomeService.DeleteIncomeDto(id);
            return RedirectToAction("Index", new { selectedDate = selectedDate.ToString("yyyy-MM-dd") });
        }

        [HttpDelete]
        [Route("DeleteOutcome")]
        public async Task<IActionResult> DeleteOutcome(string id, DateTime selectedDate)
        {
            await _outcomeService.DeleteOutcomeDto(id);
            return RedirectToAction("Index", new { selectedDate = selectedDate.ToString("yyyy-MM-dd") });
        }
    }
}
