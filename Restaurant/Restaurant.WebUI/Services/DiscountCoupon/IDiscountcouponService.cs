using Restaurant.DtoLayer.DiscountCoupondtos;

namespace Restaurant.WebUI.Services.DiscountCoupon
{
    public interface IDiscountcouponService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountsCoupons();
        Task<UpdateDiscountCouponDto> GetDiscountCouponById(int id);
        Task<ResultDiscountCouponDto> GetDiscountCouponByDiscountCouponName(string name);
        Task CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task<List<ResultDiscountCouponDto>> GetActiveCouponsAsync();
        Task DeleteDiscountCoupon(int id);
        Task<ResultDiscountCouponDto> GetDiscountCode(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
