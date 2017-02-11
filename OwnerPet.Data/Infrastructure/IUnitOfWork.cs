using System.Threading;
using System.Threading.Tasks;

namespace OwnerPet.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task CommitAsync(CancellationToken token);
    }
}
