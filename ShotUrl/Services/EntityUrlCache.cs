using Newtonsoft.Json.Linq;
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
            var url =  await _database.StringGetAsync($"ShortId:{shortUrl}");

            if (!string.IsNullOrEmpty(url))
            {
                var quant = await _database.StringIncrementAsync($"ShortId:{shortUrl}:count");
                if(quant > 1000)
                {
                    await _database.KeyExpireAsync($"ShortId:{shortUrl}", TimeSpan.FromDays(60));
                }
            }
            return url;
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
