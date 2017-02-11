using System.Data.Entity;
using OwnerPet.Data.Configurations;
using OwnerPet.Model;

namespace OwnerPet.Data.EF
{
    public class OwnerPetContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        public OwnerPetContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PetConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
