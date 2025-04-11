using MatchTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MatchTracker.Infrastructure.Data
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<ClubStat> ClubStats { get; set; }
        public DbSet<NewMatches> NewMatches { get; set; } // ✅ New table added

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Match primary key setup
            modelBuilder.Entity<NewMatches>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<NewMatches>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            // ClubStat primary key setup
            modelBuilder.Entity<ClubStat>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ClubStat>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            // NewMatches primary key setup ✅
            modelBuilder.Entity<NewMatches>()
                .HasKey(nm => nm.Id);

            modelBuilder.Entity<NewMatches>()
                .Property(nm => nm.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
