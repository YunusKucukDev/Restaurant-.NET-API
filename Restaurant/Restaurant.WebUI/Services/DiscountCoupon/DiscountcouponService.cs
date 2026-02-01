using Restaurant.DtoLayer.DiscountCoupondtos;
using System.Net;
using System.Web.Mvc;

namespace Restaurant.WebUI.Services.DiscountCoupon
{


    public class DiscountcouponService : IDiscountcouponService
    {

        private readonly HttpClient _httpClient;
        public DiscountcouponService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
          await _httpClient.PostAsJsonAsync<CreateDiscountCouponDto>("https://localhost:7200/api/DiscountsCoupon", createDiscountCouponDto);
        }

        public async Task DeleteDiscountCoupon(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7200/api/DiscountsCoupon/{id}");
        }

        public async Task<List<ResultDiscountCouponDto>> GetActiveCouponsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultDiscountCouponDto>>("https://localhost:7200/api/DiscountsCoupon/ActiveCoupons");
            return response;
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountsCoupons()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultDiscountCouponDto>>("https://localhost:7200/api/DiscountsCoupon");
            return (values);
        }

        public async Task<UpdateDiscountCouponDto> GetDiscountCouponById(int id)
        {
           var values =  await _httpClient.GetFromJsonAsync<UpdateDiscountCouponDto>($"https://localhost:7200/api/DiscountsCoupon/{id}");
              return values;
        }

        public async Task UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDiscountCouponDto>("https://localhost:7200/api/DiscountsCoupon", updateDiscountCouponDto);
        }

        public async Task<ResultDiscountCouponDto> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7200/api/Discounts/GetCodeDetailByCodeAsync?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultDiscountCouponDto>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7200/api/Discounts/GetDiscountCouponCountRate?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<ResultDiscountCouponDto?> GetDiscountCouponByDiscountCouponName(string name)
        {
            var encodedName = WebUtility.UrlEncode(name);

            var response = await _httpClient.GetAsync(
                $"https://localhost:7200/api/DiscountsCoupon/GetDiscountCouponByDiscountCouponName/{encodedName}"
            );

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ResultDiscountCouponDto>();
        }

    }
}
