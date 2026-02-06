using ShotUrl.Services.Interfaces;
using StackExchange.Redis;

namespace ShotUrl.Services
{
    public class EntityUrlCache : IEntityUrlCache
    {
        private readonly IDatabase _database;

        public EntityUrlCache(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<string> GetAsync(string shortUrl)
        {
            return await _database.StringGetAsync($"ShortId:{shortUrl}");
        }

        public async Task SetAsync(string shortUrl, string url, TimeSpan timeSpan)
        {
            await _database.StringSetAsync(
                $"ShortId:{shortUrl}",
                url,
                timeSpan
                );
        }
    }
}
