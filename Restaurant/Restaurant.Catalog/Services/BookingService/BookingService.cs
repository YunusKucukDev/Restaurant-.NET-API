using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.BookingDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Services.BookingService;
using Restaurant.Catalog.Settings;

public class BookingService : IBookingService
{
    private readonly IMongoCollection<Booking> _collection;
    private readonly IMapper _mapper;

    public BookingService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _collection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
        _mapper = mapper;
    }

    public async Task CreateBooking(CreateBookingDto dto)
    {
        var value = _mapper.Map<Booking>(dto);
        await _collection.InsertOneAsync(value);
    }

    public async Task DeleteBooking(string id)
    {
        await _collection.DeleteOneAsync(x => x.BookingId == id);
    }

    public async Task<List<ResultBookingDto>> GetAllBooking()
    {
        
        var values = await _collection.Find(x => true).ToListAsync();
        // Çekilen veriyi Map'liyoruz
        return _mapper.Map<List<ResultBookingDto>>(values);
    }

    public async Task<int> GetBookingCount()
    {
        // Tüm listeyi çekip RAM'de saymak yerine doğrudan MongoDB'den sayısını istiyoruz
        return (int)await _collection.CountDocumentsAsync(FilterDefinition<Booking>.Empty);
    }

    public async Task<ResultBookingDto> GetByIdBooking(string id)
    {
        var value = await _collection.Find(x => x.BookingId == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultBookingDto>(value);
    }

    public async Task<ResultBookingDto> GetByUserIdBooking(string userid)
    {
        var value = await _collection.Find(x => x.UserId == userid).FirstOrDefaultAsync();
        return _mapper.Map<ResultBookingDto>(value);
    }
}