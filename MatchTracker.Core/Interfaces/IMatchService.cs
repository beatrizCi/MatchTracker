namespace MatchTracker.Core.Interfaces
{
    using MatchTracker.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMatchService
    {
        Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay);
        Task ImportMatchesAsync(IEnumerable<Match> matches);
    }
}
