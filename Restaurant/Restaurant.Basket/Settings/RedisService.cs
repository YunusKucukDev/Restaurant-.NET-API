using StackExchange.Redis;

namespace Restaurant.Basket.Settings
{
    public class RedisService
    {
        private readonly string _connectionString;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _connectionString = $"{host}:{port},abortConnect=false";
        }

        public void Connect()
        {
            if (_connectionMultiplexer == null)
            {
                _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
            }
        }

        public IDatabase GetDb(int db = 0)
        {
            if (_connectionMultiplexer == null)
                Connect();

            return _connectionMultiplexer.GetDatabase(db);
        }
    }
}
