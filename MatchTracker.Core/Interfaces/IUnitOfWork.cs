using System.Threading.Tasks;

namespace MatchTracker.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IMatchRepository Matches { get; }
        Task CommitAsync();
    }
}
