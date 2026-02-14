using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Shift")]
    public class ShiftController : Controller
    {
        [HttpGet("SetShift")]
        public IActionResult SetShift(string type)
        {
            // 1. Vardiyayı kaydet
            HttpContext.Session.SetString("ActiveShift", type ?? "Gunduz");

            // 2. Gelinen sayfayı al
            string referer = Request.Headers["Referer"].ToString();

            // 3. Eğer geldiği yer belli değilse veya hata oluşursa 
            // ana hesaplama sayfasına (Computation/Index) zorla yönlendir
            if (string.IsNullOrEmpty(referer))
            {
                return RedirectToAction("Index", "Computation", new { area = "Admin" });
            }

            // 4. Geldiği sayfaya geri gönder (Sayfa yenilenmiş olacak ve yeni session'ı okuyacak)
            return Redirect(referer);
        }
    }
}
