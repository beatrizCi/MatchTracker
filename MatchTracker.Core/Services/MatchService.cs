using MatchTracker.Core.Interfaces;
using MatchTracker.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchTracker.Infrastructure.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NewMatches>> GetMatchesByDayAsync(int matchDay)
        {
            return await _unitOfWork.Matches.GetMatchesByDayAsync(matchDay);
        }

        public async Task ImportMatchesAsync(IEnumerable<NewMatches> matches)
        {
            await _unitOfWork.Matches.AddRangeAsync(matches);
            await _unitOfWork.CommitAsync();
        }
    }
}
