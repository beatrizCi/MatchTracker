using MatchTracker.Core.Models;


namespace MatchTracker.Tests.Models
{
public class MatchModelTest
    {
        [Fact]
        public void Can_Set_And_Get_Properties_On_Match()
        {
            // Arrange
            var match = new Match
            {
                Id = 1,
                TeamA = "Borussia Dortmund",
                TeamB = "Sporting CP",
                Stadium = "BVB Stadion Dortmund",
                KickOffTime = new DateTime(2025, 4, 7, 18, 0, 0),
                MatchDay = 3
            };

            // Assert
            Assert.Equal("Borussia Dortmund", match.TeamA);
            Assert.Equal("Sporting CP", match.TeamB);
            Assert.Equal("BVB Stadion Dortmund", match.Stadium);
            Assert.Equal(3, match.MatchDay);
        }
    }
}

