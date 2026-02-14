using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.DailyReport;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;


namespace Restaurant.Catalog.Services.DailyReportService
{
    public class DailyReportService : IDailyReportService
    {

        private readonly IMongoCollection<DailyReport> _collection;
        private readonly IMapper _mapper;

        public DailyReportService(
        IMongoClient mongoClient,
        IOptions<DatabaseSettings> databaseSettings,
        IMapper mapper)
        {
            var database = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = database.GetCollection<DailyReport>(
                databaseSettings.Value.DailyReportCollectionName);

            _mapper = mapper;
        }

        public async Task CreateDailyReport(CreateDailyReportDto dto)
        {
            await _collection.InsertOneAsync(_mapper.Map<DailyReport>(dto));
        }

        public async Task DeleteDailyReport(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultDailyReportDto>> GetAllDailyReports()
        {
            var result = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDailyReportDto>>(result);
        }

        public async Task<List<ResultDailyReportDto>> GetDailyReportsByShiftAsync(string shift)
        {
            // Örnek MongoDB sorgusu:
            var values = await _collection.Find(x => x.ShiftType == shift).ToListAsync();
            return _mapper.Map<List<ResultDailyReportDto>>(values);
        }
    }
}
