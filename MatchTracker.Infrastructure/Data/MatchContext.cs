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
    }
}
