using MatchTracker.Core.Models;

namespace MatchTracker.Core.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<NewMatches>> GetMatchesByDayAsync(int matchDay);
        Task ImportMatchesAsync(IEnumerable<NewMatches> matches);
    }
}
