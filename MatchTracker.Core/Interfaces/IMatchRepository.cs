using MatchTracker.Core.Models;


namespace MatchTracker.Core.Interfaces
{

    public interface IMatchRepository : IRepository<Match>
    {
        Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay);
    }

}
