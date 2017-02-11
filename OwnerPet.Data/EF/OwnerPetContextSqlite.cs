using System.Data.Entity;
using OwnerPet.Data.Initializer;

namespace OwnerPet.Data.EF
{
    public class OwnerPetContextSqlite : OwnerPetContext
    {
        public OwnerPetContextSqlite() : base("OwnerPetContextSqlite")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new SqliteInitializer(modelBuilder));
        }

    }
}
