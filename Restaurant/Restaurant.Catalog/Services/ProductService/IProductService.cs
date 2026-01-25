using Restaurant.Catalog.Dtos.ProductDtos;

namespace Restaurant.Catalog.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<GetByCategoryIdProductsDto> GetByCategoryIdProducts(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
    }
}
