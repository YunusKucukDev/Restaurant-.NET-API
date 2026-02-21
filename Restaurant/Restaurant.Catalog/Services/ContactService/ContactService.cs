using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.ContactDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.ContactService
{
    public class ContactService : IContactService
    {
        
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;

        }

        public async Task CreateContactDto(CreateContactDto dto)
        {
            await _contactCollection.InsertOneAsync(_mapper.Map<Contact>(dto));
        }

        public async Task<List<ResultContactDto>> GEtAllContacts()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactDto(string id)
        {
            var values = await _contactCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }

        public async Task<GetByUserIdContactDto> GetByUserIdContactDto(string userId)
        {
            var values = await _contactCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
            return _mapper.Map<GetByUserIdContactDto>(values);
        }
    }
}
