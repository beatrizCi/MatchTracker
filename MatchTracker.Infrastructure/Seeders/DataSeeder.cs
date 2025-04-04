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
            if (!context.Matches.Any())
            {
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
            }
        }
    }
}
