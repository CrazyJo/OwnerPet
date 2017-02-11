using System.Data.Entity;
using System.Data.Entity.Migrations;
using OwnerPet.Data.EF;
using OwnerPet.Model;
using SQLite.CodeFirst;

namespace OwnerPet.Data.Initializer
{
    public class SqliteInitializer : SqliteCreateDatabaseIfNotExists<OwnerPetContextSqlite>
    {
        public SqliteInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public SqliteInitializer(DbModelBuilder modelBuilder, bool nullByteFileMeansNotExisting) : base(modelBuilder, nullByteFileMeansNotExisting)
        {
        }

        protected override void Seed(OwnerPetContextSqlite context)
        {
            SeedUsers(context);
            SeedPets(context);
            context.SaveChanges();

            base.Seed(context);
        }

        void SeedUsers(OwnerPetContextSqlite context)
        {
            context.Users.AddOrUpdate(
                new User { Id = 1, Name = "Bob" },
                new User { Id = 2, Name = "Simpsons" },
                new User { Id = 3, Name = "Michael" },
                new User { Id = 4, Name = "Traveller" },
                new User { Id = 5, Name = "Byron" },
                new User { Id = 6, Name = "Chatwin" },
                new User { Id = 7, Name = "Bruno" },
                new User { Id = 8, Name = "Brian" },
                new User { Id = 9, Name = "Brent" },
                new User { Id = 10, Name = "Axel" },
                new User { Id = 11, Name = "Atwood" },
                new User { Id = 12, Name = "Eldon" },
                new User { Id = 13, Name = "Foster" },
                new User { Id = 14, Name = "Arlen" },
                new User { Id = 15, Name = "Freeman" });
        }

        void SeedPets(OwnerPetContextSqlite context)
        {
            context.Pets.AddOrUpdate(
                new Pet { Name = "Santa's Little Helper", OwnerId = 2 },
                new Pet { Name = "Snowball", OwnerId = 2 },
                new Pet { Name = "Snowball", OwnerId = 3 },
                new Pet { Name = "Aescford", OwnerId = 1 },
                new Pet { Name = "Baby girl", OwnerId = 4 },
                new Pet { Name = "Muffin", OwnerId = 4 },
                new Pet { Name = "Ducky", OwnerId = 5 },
                new Pet { Name = "Baby cakes", OwnerId = 6 },
                new Pet { Name = "Pudding", OwnerId = 7 },
                new Pet { Name = "Gorgeous", OwnerId = 7 },
                new Pet { Name = "Darling", OwnerId = 7 },
                new Pet { Name = "Honey", OwnerId = 8 },
                new Pet { Name = "Precious", OwnerId = 9 },
                new Pet { Name = "Baby doll", OwnerId = 9 },
                new Pet { Name = "Snookums", OwnerId = 10 },
                new Pet { Name = "Bocley", OwnerId = 11 },
                new Pet { Name = "Allard", OwnerId = 12 });

        }
    }
}
