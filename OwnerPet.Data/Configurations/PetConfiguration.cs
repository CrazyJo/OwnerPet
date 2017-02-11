using OwnerPet.Model;

namespace OwnerPet.Data.Configurations
{
    class PetConfiguration : EntityConfiguration<Pet>
    {
        public PetConfiguration()
        {
            HasRequired(p => p.Owner);
        }
    }
}
