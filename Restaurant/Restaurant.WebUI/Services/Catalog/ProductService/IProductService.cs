using Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos;

namespace Restaurant.WebUI.Services.Catalog.ProductService
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProducts();
        Task<UpdateProductDto> GetByIdProduct(string productId);
        Task<GetByCategoryIdProductDto> GetByCategoryIdProduct(string productId);
        Task CreateProduct(CreateProductDto createProductDto);
        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task DeleteProduct(string productId);

    }
}
