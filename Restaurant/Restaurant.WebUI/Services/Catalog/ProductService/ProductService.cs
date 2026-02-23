using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos;
using System.Net.Http.Json;

namespace Restaurant.WebUI.Services.Catalog.ProductService
{

    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("http://localhost:7000/api/Products", createProductDto);

        }

        public async Task DeleteProduct(string productId)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/Products/{productId}");
        }

        public async Task<List<ResultProductDto>> GetAllProducts()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("http://localhost:7000/api/Products");
            return values;
        }

        public async Task<GetByCategoryIdProductDto> GetByCategoryIdProduct(string productId)
        {
            var values = await  _httpClient.GetFromJsonAsync<GetByCategoryIdProductDto>($"http://localhost:7000/api/Products/GetByCategoryIdProducts/{productId}");
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProduct(string productId)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateProductDto>($"http://localhost:7000/api/Products/{productId}");
            return values;
        }

        public async Task<int> GetProductCount()
        {
            var response = await _httpClient.GetFromJsonAsync<int>("http://localhost:7000/api/Products/GetProductCount");
            return response;
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("http://localhost:7000/api/Products", updateProductDto);
        }
    }
}
