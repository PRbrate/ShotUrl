using ShotUrl.Model;
using ShotUrl.Repository.Interfaces;
using ShotUrl.Services.Interfaces;
using System.Text.RegularExpressions;

namespace ShotUrl.Services
{
    public class EntityUrlService : IEntityUrlService
    {
        private readonly IEntityUrlRepository _repository;
        private readonly IEntityUrlCache _cache;

        public EntityUrlService(IEntityUrlRepository repository, IEntityUrlCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<string> CreateUrl(string principalUrl)
        {
            var id = await _repository.GetNextIdAsync();

            var ofusc = CodeGenerate.ofusc(id);
            var shortId = CodeGenerate.Encode(ofusc);

            string pattern = @"^https://.*$";

            if (!Regex.IsMatch(principalUrl, pattern))
            {
                principalUrl = "https://" + principalUrl;
            }

            var entity = new EntityUrl
            {
                ShortId = shortId,
                OriginalUrl = principalUrl
            };

            var response = await _repository.CreateShotUrl(entity);

            if (response)
            {
                return (shortId);
            }
            return "";


        }

        public async Task<string> GetUrl(string shortUrl)
        {
            var cache = await _cache.GetAsync(shortUrl);
            if(cache != null)
            {
                return cache;
            }
            var url =  await _repository.GetUrl(shortUrl);

            await _cache.SetAsync(shortUrl, url.OriginalUrl, TimeSpan.FromDays(60));
            return url.OriginalUrl;

        }
    }
}
