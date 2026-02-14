


using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.FixedExpenseDto;
using Restaurant.WebUI.Services.Catalog.FixedExpense;


[Area("Admin")]
[Route("Admin/[controller]/[action]")] // Daha güvenli ve otomatik route
public class FixedExpenseController : Controller
{
    private readonly IFixedExpenseService _service;

    public FixedExpenseController(IFixedExpenseService service)
    {
        _service = service;
    }

    [HttpGet] 
    public async Task<IActionResult> Index()
    {
        ViewBag.HideShiftButtons = true;
        var values = await _service.GetAllFixedExpense();
        return View(values);
    }

    [HttpGet] 
    public IActionResult CreateFixedExpense()
    {
        ViewBag.HideShiftButtons = true;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFixedExpense(CreateFixedExpense dto)
    {
        var activeShift = HttpContext.Session.GetString("ActiveShift") ?? "Gunduz";
        dto.ShiftType = activeShift;

        await _service.CreateFixedExpense(dto);
        return RedirectToAction("Index");
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> UpdateFixedExpense(string id)
    {
        ViewBag.HideShiftButtons = true;
        var value = await _service.GetByIdFixedExpense(id);
        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFixedExpense(UpdateFixedExpense dto)
    {
        var activeShift = HttpContext.Session.GetString("ActiveShift") ?? "Gunduz";
        dto.ShiftType = activeShift;

        await _service.UpdateFixedExpense(dto);
        return RedirectToAction("Index");
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> DeleteFixedExpense(string id)
    {
        await _service.DeleteFixedExpense(id);
        return RedirectToAction("Index");
    }
}