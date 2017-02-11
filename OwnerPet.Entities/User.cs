using System.Collections.Generic;

namespace OwnerPet.Entities
{
    public class User : Entity
    {
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
