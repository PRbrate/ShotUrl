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
            return await _context.Database.SqlQueryRaw<long>("SELECT NEXTVAL('public.\"URL_NEXT_VAL\"') as \"Value\"").SingleAsync();
        }


        public async Task<string> GetUrl(string shortUrl)
        {
            var principalUrl = await _context.EntityUrls.FindAsync(shortUrl);
            if (principalUrl != null) 
            {
                return principalUrl.OriginalUrl;
            }
            return "";
        }

        public async Task<bool> CreateShotUrl(EntityUrl entity)
        {
            _context.EntityUrls.Add(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        
    }
}
