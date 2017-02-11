namespace OwnerPet.Model
{
    public class Pet : Entity
    {
        public Pet()
        {
        }

        public Pet(string name)
        {
            Name = name;
        }

        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
    }
}
