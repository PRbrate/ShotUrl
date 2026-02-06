namespace ShotUrl.Services.Interfaces
{
    public interface IEntityUrlCache
    {
        Task<string> GetAsync(string shorUrl);
        Task SetAsync(string shortUrl, string url, TimeSpan timeSpan);
    }
}
