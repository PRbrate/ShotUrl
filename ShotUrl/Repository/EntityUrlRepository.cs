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
        
        public async Task<long> GetNextIdAsync()
        {
            return await _context.Database.SqlQueryRaw<long>("Select nextval('short_url_seq')").SingleAsync();
        }

        public async Task<EntityUrl> GetUrl(string shortUrl)
        {
            var principalUrl = await _context.EntityUrls.FindAsync(shortUrl);
            return principalUrl;
        }

        public async Task<EntityUrl> CreateShotUrl(string principalUrl)
        {
            var teste = GetNextIdAsync();
            return null;

        }

        
    }
}
