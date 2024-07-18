

namespace MatchTracker.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMatchRepository Matches { get; }
        Task<int> CompleteAsync();
    }

}
