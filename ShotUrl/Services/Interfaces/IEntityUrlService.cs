namespace ShotUrl.Services.Interfaces
{
    public interface IEntityUrlService
    {
        Task<string> CreateUrl(string principalUrl);
        Task<string> GetUrl(string shorUrl);

    }
}
