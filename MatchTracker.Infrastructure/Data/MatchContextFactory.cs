using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MatchTracker.Infrastructure.Data;


namespace MatchTracker.Infrastructure.Data
{
 public class MatchContextFactory : IDesignTimeDbContextFactory<MatchContext>
    {
        public MatchContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MatchContext>();
            optionsBuilder.UseSqlite("Data Source=matchtracker.db");

            return new MatchContext(optionsBuilder.Options);
        }
    }
}
