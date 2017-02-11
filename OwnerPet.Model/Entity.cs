namespace OwnerPet.Model
{
    public abstract class Entity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id.ToString()} {Name}";
        }
    }
}
