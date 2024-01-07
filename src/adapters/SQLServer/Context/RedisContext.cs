using Shared.Exceptions;
using StackExchange.Redis;

namespace SQLServer.Context
{
    public class RedisContext
    {
        private readonly IDatabase _db;
        private DateTimeOffset CachingExpiration { get; set; }
        public RedisContext(string connection, string cachingExpiration)
        {
            Connect(connection);

            _db = Connection.GetDatabase();

            CachingExpiration = DateTimeOffset.Now.AddHours(int.Parse(cachingExpiration));
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        public void Connect(string host)
        {
            try
            {
                lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                    return ConnectionMultiplexer.Connect(host);
                });
            }
            catch(RedisConnectionException err)
            {
                throw new InfraException(err);
            }
        }
    }
}
