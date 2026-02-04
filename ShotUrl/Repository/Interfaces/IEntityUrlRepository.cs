using ShotUrl.Model;

namespace ShotUrl.Repository.Interfaces
{
    public interface IEntityUrlRepository
    {
        Task<EntityUrl> GetUrl(string shortUrl);
        Task CreateShotUrl(string principalUrl);
    }
}
