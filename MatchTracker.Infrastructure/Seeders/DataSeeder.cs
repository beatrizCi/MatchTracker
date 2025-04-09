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
                        KickOffTime = new DateTime(2024, 8, 1, 12, 0, 0),
                        Stadium = "Santiago Bernabéu",
                        MatchDay = 1
                    },
                    new Match
                    {
                        TeamA = "Bayern Munich",
                        TeamB = "Liverpool",
                        KickOffTime = new DateTime(2024, 8, 1, 14, 0, 0),
                        Stadium = "Allianz Arena",
                        MatchDay = 1
                    },
                    new Match
                    {
                        TeamA = "PSG",
                        TeamB = "Chelsea",
                        KickOffTime = new DateTime(2024, 8, 2, 16, 0, 0),
                        Stadium = "Parc des Princes",
                        MatchDay = 2
                    },
                    new Match
                    {
                        TeamA = "Barcelona",
                        TeamB = "Juventus",
                        KickOffTime = new DateTime(2024, 8, 2, 18, 0, 0),
                        Stadium = "Camp Nou",
                        MatchDay = 2
                    }
                );

                context.SaveChanges();
                Console.WriteLine("✅ Matches seeded.");
            }

            if (!context.ClubStats.Any())
            {
                Console.WriteLine("📌 Seeding ClubStats...");

                context.ClubStats.AddRange(
                    new ClubStat
                    {
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/en/1/1f/FC_Bayern_München_logo_(2017).svg",
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
                    },
                    new ClubStat
                    {
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/en/0/0c/Liverpool_FC.svg",
                        ClubName = "Liverpool",
                        Country = "England",
                        MatchesPlayed = 10,
                        Won = 5,
                        Drawn = 1,
                        Lost = 4
                    },
                    new ClubStat
                    {
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/en/0/03/Manchester_City_FC_badge.svg",
                        ClubName = "Manchester City",
                        Country = "England",
                        MatchesPlayed = 11,
                        Won = 7,
                        Drawn = 2,
                        Lost = 2
                    }
                );

                context.SaveChanges();
                Console.WriteLine("✅ ClubStats seeded.");
            }

            Console.WriteLine("🚀 Seeding complete.");
        }
    }
}
