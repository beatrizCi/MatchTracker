using MatchTracker.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchTracker.Core.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay);
        Task AddRangeAsync(IEnumerable<Match> matches);
    }
}
