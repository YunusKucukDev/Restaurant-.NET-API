using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant.WebUI.Services.Catalog.OutcomeService; // Session için gerekli

namespace Restaurant.WebUI.ViewComponents
{
    public class ListOutcome : ViewComponent
    {
        private readonly IOutcomeService _outcomeService;

        public ListOutcome(IOutcomeService outcomeService)
        {
            _outcomeService = outcomeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime selectedDate)
        {
            var activeShift = HttpContext.Session.GetString("ActiveShift") ?? "Gunduz";
            ViewBag.SelectedDate = selectedDate.ToString("yyyy-MM-dd");
            var values = await _outcomeService.GetAllOutcomes();
            var filteredValues = values
                .Where(x => x.Date.Date == selectedDate.Date &&
                            x.ShiftType == activeShift)
                .OrderByDescending(x => x.OutcomeId)
                .ToList();

            return View(filteredValues);
        }
    }
}