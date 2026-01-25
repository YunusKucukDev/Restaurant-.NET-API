using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.CategoryDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly IMongoCollection<Category> _collection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;

        }


        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _collection.InsertOneAsync(_mapper.Map<Category>(createCategoryDto));
        }


        public async Task DeleteCategoryAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.CategoryId == id);
        }


        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _collection.Find(category => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }


        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await  _collection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task<List<CategorySelectDto>> GetCategoriesForSelectAsync()
        {
            var categories = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<CategorySelectDto>>(categories);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _collection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, _mapper.Map<Category>(updateCategoryDto));
        }
    }
}
