using System.Linq;
using OwnerPet.Data.Infrastructure;
using OwnerPet.Data.Repositories;
using OwnerPet.Model;
using OwnerPet.Service.Interfaces;

namespace OwnerPet.Service
{
    public class UserService : CrudService<User, int>, IUserService
    {
        public UserService(IRepository<User, int> repository, IUnitOfWork database) : base(repository, database)
        {
        }

        protected override IQueryable<User> GetAllDbEntities()
        {
            return Repository.GetAllIncluding(u => u.Pets);
        }
    }
}
