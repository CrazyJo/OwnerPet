using Ninject.Modules;
using OwnerPet.Data.Infrastructure;
using OwnerPet.Data.Repositories;
using OwnerPet.Model;

namespace OwnerPet.Service
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbFactory>().To<OwnerPetSqliteFactory>().InThreadScope();
            Bind<IUnitOfWork>().To<OwnerPetUoW>();
            Bind<IRepository<User, int>>().To<EntityRepository<User, int>>();
            Bind<IRepository<Pet, int>>().To<EntityRepository<Pet, int>>();
        }
    }
}
