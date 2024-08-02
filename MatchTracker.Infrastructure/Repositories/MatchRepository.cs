using MatchTracker.Core.Interfaces;
using MatchTracker.Core.Models;
using MatchTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace MatchTracker.Infrastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly MatchContext _context;

        public MatchRepository(MatchContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay)
        {
            return await _context.Matches
                .Where(m => m.MatchDay == matchDay)
                .OrderByDescending(m => m.KickOffTime)
                .ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Match> matches)
        {
            await _context.Matches.AddRangeAsync(matches);
            await _context.SaveChangesAsync();
        }
    }
}
