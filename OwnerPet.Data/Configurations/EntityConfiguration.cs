using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OwnerPet.Model;

namespace OwnerPet.Data.Configurations
{
    public abstract class EntityConfiguration<T> : EntityTypeConfiguration<T> where T : Entity
    {
        protected EntityConfiguration()
        {
            HasKey(e => e.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsRequired().HasMaxLength(100);
        }
    }
}
