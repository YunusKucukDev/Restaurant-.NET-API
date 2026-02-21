using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
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


    [HttpGet("Index")]
    public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
    {
        var values = await _basketService.GetBasket();
        

        if (values == null || !values.BasketItems.Any())
        {
            values.DiscountCode = null;
            values.DiscountRate = null;
            await _basketService.SaveBasket(values);
        }

        // 2. Durum: Süre kontrolü (10 dakika doldu mu?)
        if (Request.Cookies.TryGetValue("CouponExpireTime", out string expireStr))
        {
            DateTime expireTime = DateTime.Parse(expireStr);
            if (DateTime.Now > expireTime)
            {
                values.DiscountCode = null;
                values.DiscountRate = null;
                await _basketService.SaveBasket(values);
                Response.Cookies.Delete("CouponExpireTime");
            }
        }
        else if (values.DiscountRate > 0)
        {
            values.DiscountCode = null;
            values.DiscountRate = null;
            await _basketService.SaveBasket(values);
        }

        decimal menuTotal = values.TotalPrice;
        decimal discountAmount = 0;

        if (values.DiscountRate.HasValue && values.DiscountRate.Value > 0)
        {
            discountAmount = menuTotal * values.DiscountRate.Value / 100;
        }
        decimal discountedMenuPrice = menuTotal - discountAmount;
        decimal subTotalExcludingTax = discountedMenuPrice / 1.1m;
        decimal taxAmount = discountedMenuPrice - subTotalExcludingTax;
        decimal finalTotal = discountedMenuPrice; 

       
        ViewBag.MenuTotal = menuTotal;
        ViewBag.Discount = discountAmount;
        ViewBag.SubTotal = subTotalExcludingTax;
        ViewBag.Tax = taxAmount;
        ViewBag.FinalTotal = finalTotal;

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


    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        // userId parametresi zaten API tarafında loginService üzerinden alındığı için buraya boş string de gönderebilirsin
        await _basketService.DeleteBasket("");
        return RedirectToAction("Index", "Basket"); 
    }

}
