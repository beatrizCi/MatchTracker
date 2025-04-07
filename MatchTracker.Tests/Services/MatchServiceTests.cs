using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Data;
using MatchTracker.Infrastructure.Repositories;
using MatchTracker.Infrastructure.Services;
using MatchTracker.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MatchTracker.Tests.Services
{
    public class MatchServiceTests
    {
        [Fact]
        public async Task GetMatchesByDayAsync_ReturnsMatches_WhenDataExists()
        {
            // Arrange
            var services = new ServiceCollection();

            // Register DbContext using InMemory
            services.AddDbContext<MatchContext>(options =>
                options.UseInMemoryDatabase("MatchTrackerTestDb"));

            // Register MatchRepository as concrete
            services.AddScoped<MatchRepository>();
            services.AddScoped<IMatchRepository>(provider =>
                provider.GetRequiredService<MatchRepository>());

            // Register UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register MatchService
            services.AddScoped<IMatchService, MatchService>();

            var provider = services.BuildServiceProvider();

            var matchService = provider.GetRequiredService<IMatchService>();

            // Seed data
            var matchesToAdd = new List<Match>
            {
                new Match { Id = 1, TeamA = "Team A", TeamB = "Team B", MatchDay = 1, KickOffTime = DateTime.Now, Stadium = "Stadium A" },
                new Match { Id = 2, TeamA = "Team C", TeamB = "Team D", MatchDay = 2, KickOffTime = DateTime.Now, Stadium = "Stadium B" }
            };

            await matchService.ImportMatchesAsync(matchesToAdd);

            // Act
            var result = await matchService.GetMatchesByDayAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Only 1 match on MatchDay 1
        }
    }
}
