using OwnerPet.Model;

namespace OwnerPet.Data.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(p => p.Pets);
        }
    }
}
