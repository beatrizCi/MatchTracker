using MatchTracker.Core.Models;
using MatchTracker.Infrastructure.Data;
using System;
using System.Linq;

namespace MatchTracker.Infrastructure.Seeders
{
    public static class DataSeeder
    {
        public static void Seed(MatchContext context)
        {
            Console.WriteLine("⚙️ Starting database seeding...");

            if (!context.Matches.Any())
            {
                Console.WriteLine("📌 Seeding Matches...");

                context.Matches.AddRange(
                    new Match
                    {
                        TeamA = "Real Madrid",
                        TeamB = "Manchester City",
                        KickOffTime = DateTime.SpecifyKind(new DateTime(2024, 8, 1, 12, 0, 0), DateTimeKind.Utc),
                        Stadium = "Santiago Bernabéu",
                        MatchDay = 1
                    },
                    new Match
                    {
                        TeamA = "Bayern Munich",
                        TeamB = "Liverpool",
                        KickOffTime = DateTime.SpecifyKind(new DateTime(2024, 8, 1, 14, 0, 0), DateTimeKind.Utc),
                        Stadium = "Allianz Arena",
                        MatchDay = 1
                    }
                );

                try
                {
                    context.SaveChanges();
                    Console.WriteLine("✅ Matches seeded.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error saving Matches: " + ex.Message);
                }
            }

            if (!context.ClubStats.Any())
            {
                Console.WriteLine("📌 Seeding ClubStats...");

                context.ClubStats.AddRange(
                    new ClubStat
                    {
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/en/1/1f/FC_Bayern_M%C3%BCnchen_logo_(2017).svg",
                        ClubName = "Bayern München",
                        Country = "Germany",
                        MatchesPlayed = 12,
                        Won = 8,
                        Drawn = 1,
                        Lost = 3
                    },
                    new ClubStat
                    {
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/en/5/56/Real_Madrid_CF.svg",
                        ClubName = "Real Madrid",
                        Country = "Spain",
                        MatchesPlayed = 12,
                        Won = 8,
                        Drawn = 0,
                        Lost = 4
                    }
                );

                try
                {
                    context.SaveChanges();
                    Console.WriteLine("✅ ClubStats seeded.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error saving ClubStats: " + ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine("Inner: " + ex.InnerException.Message);
                }
            }

            Console.WriteLine("🚀 Seeding complete.");
        }
    }
}
