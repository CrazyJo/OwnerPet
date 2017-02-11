using OwnerPet.Model;

namespace OwnerPet.Web.Models
{
    public interface ICreature<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
    }
}
