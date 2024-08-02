using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Data;
using System.Threading.Tasks;

namespace MatchTracker.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MatchContext _context;
        private readonly IMatchRepository _matchRepository;

        public UnitOfWork(MatchContext context, IMatchRepository matchRepository)
        {
            _context = context;
            _matchRepository = matchRepository;
        }

        public IMatchRepository Matches => _matchRepository;

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
