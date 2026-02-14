using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.BasketDtos;
using Restaurant.WebUI.Services.Basket;
using Restaurant.WebUI.Services.Catalog.ProductService;
using Restaurant.WebUI.Services.Catalog.SpecialMenuService;
using Restaurant.WebUI.Services.DiscountCoupon;


[Route("Basket")]
public class BasketController : Controller
{
    private readonly IProductService _productService;
    private readonly IBasketService _basketService;
    private readonly ISpecialMenuService _specialMenuService;
    private readonly IDiscountcouponService _discountcouponService;

    public BasketController(
        IProductService productService,
        IBasketService basketService,
        ISpecialMenuService specialMenuService,
        IDiscountcouponService discountcouponService)
    {
        _productService = productService;
        _basketService = basketService;
        _specialMenuService = specialMenuService;
        _discountcouponService = discountcouponService;
    }


    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var values = await _basketService.GetBasket();

        // 1. Menü Fiyatı (KDV Dahil Ham Fiyat)
        decimal menuTotal = values.TotalPrice;

        // 2. İndirim Hesaplama (Menü fiyatı üzerinden)
        decimal discountAmount = 0;
        if (values.DiscountRate.HasValue)
        {
            discountAmount = menuTotal * values.DiscountRate.Value / 100;
        }

        // 3. İndirimli Fiyat (KDV Dahil)
        decimal discountedMenuPrice = menuTotal - discountAmount;

        // 4. KDV'siz Tutar (Ara Toplam) 
        // Formül: KDVli Fiyat / 1.10 (KDV %10 ise)
        decimal subTotalExcludingTax = discountedMenuPrice / 1.1m;

        // 5. KDV Tutarı
        // Formül: KDVli Fiyat - KDV'siz Fiyat
        decimal taxAmount = discountedMenuPrice - subTotalExcludingTax;

        // 6. Genel Toplam (KDV Dahil Ödenecek Tutar)
        decimal finalTotal = subTotalExcludingTax + taxAmount;

        // ViewBag'e gönderiyoruz
        ViewBag.MenuTotal = menuTotal;
        ViewBag.Discount = discountAmount;
        ViewBag.SubTotal = subTotalExcludingTax; // KDV'siz Ara Toplam
        ViewBag.Tax = taxAmount;               // Sadece KDV
        ViewBag.FinalTotal = finalTotal;        // KDV'li Genel Toplam

        return View(values);
    }


    [HttpGet("AddBasketItem/{id}")]
    public async Task<IActionResult> AddBasketItem(string id, string type = "product")
    {
        if (type == "special")
        {
            var specialMenu = await _specialMenuService.GetByIdSpecialMenu(id);
            if (specialMenu == null)
                return BadRequest("Special menu not found");

            await _basketService.AddBasketItem(new BasketItemDto
            {
                ProductId = specialMenu.SpecialMenuId,
                ProductName = specialMenu.SpecialMenuName,
                Price = specialMenu.Price,
                Quantity = 1,
                ProductImageUrl = specialMenu.ImageUrl
            });

            return RedirectToAction(nameof(Index));
        }

        var product = await _productService.GetByIdProduct(id);
        if (product == null)
            return BadRequest("Product not found");
         
        await _basketService.AddBasketItem(new BasketItemDto
        {
            ProductId = product.ProductId,
            ProductName = product.Name,
            Price = product.Price,
            Quantity = 1,
            ProductImageUrl = product.ImageUrl
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ApplyDiscount(string code)
    {
       
        var discount = await _discountcouponService.GetDiscountCouponByDiscountCouponName(code);

        if (discount == null)
        {
            TempData["DiscountError"] = "Geçersiz indirim kodu";
            return RedirectToAction("Index");
        }

        
        var basket = await _basketService.GetBasket();
        basket.DiscountCode = discount.Code;
        basket.DiscountRate = discount.Rate;
        await _basketService.SaveBasket(basket);

        return RedirectToAction("Index");
    }



    [HttpGet("RemoveBasketItem/{id}")]
    public async Task<IActionResult> RemoveBasketItem(string id)
    {
        await _basketService.RemoveBasketItem(id);

        var basket = await _basketService.GetBasket();

        // 🧹 Sepet boşsa indirimi temizle
        if (basket == null || !basket.BasketItems.Any())
        {
            basket.DiscountCode = null;
            basket.DiscountRate = null;

            await _basketService.SaveBasket(basket);
        }

        return RedirectToAction("Index");
    }

}
