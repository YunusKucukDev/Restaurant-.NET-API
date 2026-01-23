using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.About;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.AboutService
{
    public class AboutService : IAboutService
    {

        private readonly IMongoCollection<About> _collection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;

        }

        public async Task CreateAboutDto(CreateAboutDto createAboutDto)
        {
             await _collection.InsertOneAsync(_mapper.Map<About>(createAboutDto));
        }

        public async Task DeleteAboutDto(string id)
        {
            await _collection.DeleteOneAsync(x => x.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAbouts()
        {
            var values = await _collection.Find(about => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByIdAbotDto(string id)
        {
            var values = await _collection.Find(x =>x.AboutId == id ).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(values);
        }

        public async Task UpdateAboutDto(UpdateAboutDto updateAboutDto)
        {
            await _collection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, _mapper.Map<About>(updateAboutDto));
        }
    }
}
