using MatchTracker.Core.Models;

namespace MatchTracker.Core.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay);
        Task ImportMatchesAsync(IEnumerable<Match> matches);
    }
}
