using System.Collections.Generic;

namespace OwnerPet.Model
{
    public class User : Entity
    {
        public virtual ICollection<Pet> Pets { get; set; }

        public User()
        {
            Pets = new List<Pet>();
        }

        public User(int id) : this()
        {
            Id = id;
        }

        public User(string name) : this()
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Pets.Count.ToString()}";
        }
    }
}
