namespace OwnerPet.Web.Models
{
    public class UserViewModel : ICreature<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetsCount { get; set; }
    }
}