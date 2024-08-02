using MatchTracker.Core.Models;
using MatchTracker.Infrastructure.Data;

namespace MatchTracker.Infrastructure.Seeders
{
    public static class DataSeeder
    {
        public static void Seed(MatchContext context)
        {
            if (!context.Matches.Any())
            {
                var matches = new List<Match>
                {
                    new Match { MatchDay = 1, TeamA = "Team A", TeamB = "Team B", KickOffTime = DateTime.Now, Stadium = "Stadium 1" },
                    new Match { MatchDay = 1, TeamA = "Team C", TeamB = "Team D", KickOffTime = DateTime.Now.AddHours(1), Stadium = "Stadium 2" },
                    // Add more matches as needed
                };

                context.Matches.AddRange(matches);
                context.SaveChanges();
            }
        }
    }
}
