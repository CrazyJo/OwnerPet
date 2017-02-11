using OwnerPet.Data.Infrastructure;
using OwnerPet.Data.Repositories;
using OwnerPet.Model;
using OwnerPet.Service.Interfaces;

namespace OwnerPet.Service
{
    public class PetService : CrudService<Pet, int>, IPetService
    {
        public PetService(IRepository<Pet, int> repository, IUnitOfWork database) : base(repository, database)
        {
        }
    }
}
