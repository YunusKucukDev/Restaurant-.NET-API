using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.SpecialMenuDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.SpecialMenuService
{
    public class SpecialMenuService : ISpecialMenuService
    {

        private readonly IMongoCollection<SpecialMenu> _specialMenuCollection;
        private readonly IMapper _mapper;

        public SpecialMenuService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialMenuCollection = database.GetCollection<SpecialMenu>(_databaseSettings.SpecialMenuCollectionName);
            _mapper = mapper;

        }

        public async Task CreateSpecialMenuAsync(CreateSpecialMenuDto createSpecialMenuDto)
        {
            await _specialMenuCollection.InsertOneAsync(_mapper.Map<SpecialMenu>(createSpecialMenuDto));
        }

        public async Task DeleteSpecialMenuAsync(string specialMenuId)
        {
            await _specialMenuCollection.DeleteOneAsync(x => x.SpecialMenuId == specialMenuId);
        }

        public async Task<GetByIdSpecialMenuDto> GetByIdSpecialMenuAsync(string specialMenuId)
        {
           var values = await _specialMenuCollection.FindAsync(x => x.SpecialMenuId == specialMenuId);
              return _mapper.Map<GetByIdSpecialMenuDto>(values.FirstOrDefault());
        }

        public async Task<int> GetSpecialMenuCount()
        {
            return (int)await _specialMenuCollection.Find(x => true).CountDocumentsAsync();
        }

        public async Task<List<ResultSpecialMenuDto>> GetSpecialMenusAsync()
        {
            var values = _specialMenuCollection.FindAsync(x => true).Result.ToList();
            return _mapper.Map<List<ResultSpecialMenuDto>>(values);
        }

        public async Task UpdateSpecialMenuAsync(UpdateSpecialMenuDto updateSpecialMenuDto)
        {
            await _specialMenuCollection.ReplaceOneAsync(x => x.SpecialMenuId == updateSpecialMenuDto.SpecialMenuId, _mapper.Map<SpecialMenu>(updateSpecialMenuDto));
        }
    }
}
