using Microsoft.EntityFrameworkCore;
using ShotUrl.Model;
using ShotUrl.Repository.Interfaces;

namespace ShotUrl.Repository
{
    public class EntityUrlRepository : IEntityUrlRepository
    {
        private readonly AppDbContext _context;

        public EntityUrlRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<EntityUrl> GetUrl(string shortUrl)
        {
            var principalUrl = await _context.EntityUrls.FindAsync(shortUrl);
            return principalUrl;
        }

        public async Task CreatShotUrl(string principalUrl)
        {
            var url = new EntityUrl() { BaseUrl = principalUrl };
            _context.EntityUrls.Add(url);
            await _context.SaveChangesAsync();

        }

        
    }
}
