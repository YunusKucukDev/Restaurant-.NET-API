using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.CategoryDtos;
using Restaurant.Catalog.Dtos.ProductDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;

        }


        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(createCategoryDto));
        }


        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }


        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _categoryCollection.Find(category => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }


        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task<List<CategorySelectDto>> GetCategoriesForSelectAsync()
        {
            var categories = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<CategorySelectDto>>(categories);
        }

        public async Task<List<ResultCategoryDto>> GetCategoriesWithProductsAsync()
        {
            var categories = await _categoryCollection.Find(x => true).ToListAsync(); 
            var products = await _productCollection.Find(x => true).ToListAsync(); 

            var result = categories
                .OrderBy(x => x.DisplayOrder)   
                .Select(category => new ResultCategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.Name,
                    DisplayOrder = category.DisplayOrder,

                    Products = products
                        .Where(p => p.CategoryId == category.CategoryId && p.IsAvailable)
                        .OrderBy(p => p.DisplayOrder)  
                        .Select(p => new ResultProductDto
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Price = p.Price,
                            Description = p.Description,
                            IsAvailable = p.IsAvailable,
                            ImageUrl = p.ImageUrl,
                            CategoryId = p.CategoryId,
                            DisplayOrder = p.DisplayOrder
                        })
                        .ToList()
                })
                .ToList();

            return result;
        }

        public async Task<int> GetCategoryCount()
        {
            return (int)await _categoryCollection.CountDocumentsAsync(category => true);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, _mapper.Map<Category>(updateCategoryDto));
        }
    }
}
