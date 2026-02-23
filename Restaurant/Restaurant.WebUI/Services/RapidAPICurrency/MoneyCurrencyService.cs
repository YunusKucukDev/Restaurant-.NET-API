using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Restaurant.WebUI.Services.RapidAPICurrency
{
    public class MoneyCurrencyService
    {
        private readonly HttpClient _httpClient;

        // Constructor ekledik: Bu sayede hata ortadan kalkacak
        public MoneyCurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCurrency()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange-rate-api1.p.rapidapi.com/latest"),
                Headers =
                {
                    { "x-rapidapi-key", "f98194c225msh0e76c5ec933fe45p10715ejsn15ca207622ff" },
                    { "x-rapidapi-host", "currency-exchange-rate-api1.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}