using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.ProductDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;

        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            var result = _mapper.Map<List<ResultProductDto>>(
                products,
                opt =>
                {
                    opt.Items["categories"] = categories;
                });

            return result;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<GetByCategoryIdProductsDto> GetByCategoryIdProducts(string id)
        {
            var values = await _productCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByCategoryIdProductsDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, _mapper.Map<Product>(updateProductDto));   
        }
    }
}
