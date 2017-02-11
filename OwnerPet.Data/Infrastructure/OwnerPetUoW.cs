using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace OwnerPet.Data.Infrastructure
{
    public class OwnerPetUoW : IUnitOfWork
    {
        public DbContext Context { get; }

        public OwnerPetUoW(IDbFactory factory)
        {
            Context = factory.GetContext();
        }

        public async Task CommitAsync()
        {
            await CommitAsync(CancellationToken.None);
        }

        public async Task CommitAsync(CancellationToken token)
        {
            await Context.SaveChangesAsync(token);
        }
    }
}
