using ShotUrl.Model;
using ShotUrl.Repository.Interfaces;
using ShotUrl.Services.Interfaces;
using System.Text.RegularExpressions;

namespace ShotUrl.Services
{
    public class EntityUrlService : IEntityUrlService
    {
        private readonly IEntityUrlRepository _repository;

        public EntityUrlService(IEntityUrlRepository repository)
        {
            _repository = repository;
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

        public async Task<string> GetUrl(string shorUrl)
        {
            return await _repository.GetUrl(shorUrl);
        }
    }
}
