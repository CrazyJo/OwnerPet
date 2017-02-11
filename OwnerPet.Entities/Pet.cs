namespace OwnerPet.Entities
{
    public class Pet : Entity
    {
        public virtual User Owner { get; set; }
    }
}
