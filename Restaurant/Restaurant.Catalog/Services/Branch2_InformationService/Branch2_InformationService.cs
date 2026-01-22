using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.Branch2_Dtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.Branch2_InformationService
{
    public class Branch2_InformationService : IBranch2_InformationService
    {

        private readonly IMongoCollection<Branch2_Information> _collection;
        private readonly IMapper _mapper;

        public Branch2_InformationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collection = database.GetCollection<Branch2_Information>(_databaseSettings.Branch2_InformationCollectionName);
            _mapper = mapper;

        }

        public  async Task CreateBranch2_Information(CreateBranc2_Dto createBranc2_Dto)
        {
            var values =   _mapper.Map<Branch2_Information>(createBranc2_Dto);
            await _collection.InsertOneAsync(values);
        }

        public async Task DeleteBranch2_Information(string id)
        {
            await _collection.DeleteOneAsync(x => x.BranchId == id);
        }

        public async Task<List<ResultBranc2_Dto>> GetAllBranch2_Information()
        {
            var values = await  _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBranc2_Dto>>(values);
        }

        public async Task<GetByIdBranc2_Dto> GetByIdBranch2_Information(string id)
        {
            var entity = await _collection.Find(x => x.BranchId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBranc2_Dto>(entity);
        }

        public async Task UpdateBranch2_Information(UpdateBranc2_Dto updateBranc2_Dto)
        {
            var values = _mapper.Map<Branch2_Information>(updateBranc2_Dto);
            await _collection.ReplaceOneAsync(x => x.BranchId == updateBranc2_Dto.BranchId, values);
        }
    }
}
