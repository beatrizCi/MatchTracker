using MatchTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchTracker.Infrastructure.Data
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<ClubStat> ClubStats { get; set; }

        // 🔥 This is where the magic happens — correctly overriding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // <- still important!

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ClubStat>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
