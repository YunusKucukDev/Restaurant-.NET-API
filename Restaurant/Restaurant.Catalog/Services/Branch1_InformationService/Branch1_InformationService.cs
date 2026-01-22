using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.Branch1_Dtos;
using Restaurant.Catalog.Dtos.Branch2_Dtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.Branch1_InformationService
{
    public class Branch1_InformationService : IBranch_InformationService
    {

        private readonly IMongoCollection<Branch1_Information> _collection;
        private readonly IMapper _mapper;

        public Branch1_InformationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collection = database.GetCollection<Branch1_Information>(_databaseSettings.Branch1_InformationCollectionName);
            _mapper = mapper;

        }

        public async Task CreateBranch1_Information(CreateBranc1_Dto createBranc1_Dto)
        {
            try
            {
                var values = _mapper.Map<Branch1_Information>(createBranc1_Dto);
                await _collection.InsertOneAsync(values);

            }
            catch (MongoWriteException ex)
            {
                throw new Exception("Create Branch method Have some Error.", ex);
            }
        }

        public async Task DeleteBranch1_Information(string id)
        {
            try
            {
               await _collection.DeleteOneAsync(x => x.BranchId == id);

            }
            catch (MongoWriteException ex)
            {
                throw new Exception("Delete Branch method Have some Error.", ex);
            }
        }

        public async Task<List<ResultBranc1_Dto>> GetAllBranch1_Information()
        {
            try
            {
                var values = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBranc1_Dto>>(values);

            }
            catch (MongoWriteException ex)
            {
                throw new Exception("GetAll Branch method Have some Error.", ex);
            }
        }

        public async Task<GetByIdBranc1_Dto> GetByIdBranch1_InformationById(string id)
        {
            try
            {
                var entity = await _collection
                    .Find(x => x.BranchId == id)
                    .FirstOrDefaultAsync();

                if (entity == null)
                    return null;

                return _mapper.Map<GetByIdBranc1_Dto>(entity);
            }
            catch (MongoException ex)
            {
                throw new Exception("GetById Branch method error.", ex);
            }
        }

        public async Task UpdateBranch1_Information(UpdateBranc1_Dto updateBranc1_Dto)
        {
            try
            {
                var values = _mapper.Map<Branch1_Information>(updateBranc1_Dto);
            await _collection.FindOneAndReplaceAsync(x => x.BranchId == updateBranc1_Dto.BranchId,values);

            }
            catch (MongoWriteException ex)
            {
                throw new Exception("Update Branch method Have some Error.", ex);
            } 
        }
    }
}
