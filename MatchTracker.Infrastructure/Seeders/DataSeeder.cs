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

            if (!context.NewMatches.Any())
            {
                Console.WriteLine("📌 Seeding NewMatches...");

                context.NewMatches.AddRange(
                    new NewMatches
                    {
                        TeamA = "Napoli",
                        TeamB = "Inter Milan",
                        KickOffTime = DateTime.SpecifyKind(new DateTime(2024, 8, 3, 18, 0, 0), DateTimeKind.Utc),
                        Stadium = "Stadio Diego Armando Maradona",
                        MatchDay = 3
                    },
                    new NewMatches
                    {
                        TeamA = "Arsenal",
                        TeamB = "Tottenham",
                        KickOffTime = DateTime.SpecifyKind(new DateTime(2024, 8, 4, 16, 30, 0), DateTimeKind.Utc),
                        Stadium = "Emirates Stadium",
                        MatchDay = 3
                    }
                );

                context.SaveChanges();
                Console.WriteLine("✅ NewMatches seeded.");
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
