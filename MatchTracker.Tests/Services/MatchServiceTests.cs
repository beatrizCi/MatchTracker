using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Services;
using Moq;


namespace MatchTracker.Tests.Services
{
  public class MatchServiceTests
    {
        [Fact]
        public Task MatchService_ShouldBeCreated_WithMockedUnitOfWork()
        {
            // Arrange
            var mockRepo = new Mock<IMatchRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(u => u.Matches).Returns(mockRepo.Object);

            var matchService = new MatchService(mockUow.Object);

            // Act
            // Optionally call something like:
            // var result = await matchService.GetAllMatches();

            // Assert
            Assert.NotNull(matchService);
            return Task.CompletedTask;
        }
    }
}
