using ShotUrl.Model;

namespace ShotUrl.Repository.Interfaces
{
    public interface IEntityUrlRepository
    {
        Task<string> GetUrl(string shortUrl);
        Task<bool> CreateShotUrl(EntityUrl entity);
        Task<long> GetNextIdAsync();
    }
}
