using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace MatchTracker.Tests.Services
{
  public class MatchServiceTests
    {
        [Fact]
        public void ShouldResolveMyService()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMatchService, MatchService>();

            var provider = services.BuildServiceProvider();
            var service = provider.GetService<IMatchService>();

            Assert.NotNull(service);
        }

    }
}
