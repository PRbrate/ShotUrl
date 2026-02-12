using Microsoft.EntityFrameworkCore;
using ShotUrl.Model;

namespace ShotUrl.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<EntityUrl> EntityUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EntityUrl>().HasKey(u => u.ShortId);
            modelBuilder.Entity<EntityUrl>().HasIndex(u => u.ShortId).IsUnique();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
