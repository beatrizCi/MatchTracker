namespace MatchTracker.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MatchTracker.Core.Interfaces;
    using MatchTracker.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MatchTracker.Infrastructure.Data;

    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(MatchContext context) : base(context) { }

        public async Task<IEnumerable<Match>> GetMatchesByDayAsync(int matchDay)
        {
            return await Context.Set<Match>()
                                .Where(m => m.MatchDay == matchDay)
                                .OrderByDescending(m => m.KickOffTime)
                                .ToListAsync();
        }

        public new void Remove(Match entity)
        {
            base.Remove(entity);
        }
    }
}
