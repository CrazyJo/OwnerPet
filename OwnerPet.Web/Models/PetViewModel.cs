namespace OwnerPet.Web.Models
{
    public class PetViewModel : ICreature<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
    }
}