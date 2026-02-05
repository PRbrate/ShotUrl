using ShotUrl.Model;

namespace ShotUrl.Repository.Interfaces
{
    public interface IEntityUrlRepository
    {
        Task<EntityUrl> GetUrl(string shortUrl);
        Task<string> CreateShotUrl(string principalUrl);
    }
}
