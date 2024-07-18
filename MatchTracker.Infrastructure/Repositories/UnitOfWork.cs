using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Data;

namespace MatchTracker.Infrastructure.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MatchContext _context;

        public UnitOfWork(MatchContext context)
        {
            _context = context;
            Matches = new MatchRepository(_context);
        }

        public IMatchRepository Matches { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

