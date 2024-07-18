namespace MatchTracker.Core.Services
{
    using MatchTracker.Core.Interfaces;
    using MatchTracker.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay)
        {
            return await _unitOfWork.Matches.GetMatchesByDayAsync(matchDay);
        }

        public async Task ImportMatchesAsync(IEnumerable<Match> matches)
        {
            foreach (var match in matches)
            {
                await _unitOfWork.Matches.AddAsync(match);
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
