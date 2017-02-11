using System;
using System.Data.Entity;
using System.Threading;
using OwnerPet.Data.EF;

namespace OwnerPet.Data.Infrastructure
{
    public class OwnerPetSqliteFactory : IDbFactory
    {
        protected DbContext DbContext;
        protected bool Disposed { get; set; }

        public DbContext GetContext()
        {
            LazyInitializer.EnsureInitialized(ref DbContext, Init);
            return DbContext;
        }

        protected virtual DbContext Init()
        {
            var dbContext = new OwnerPetContextSqlite();

            return dbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext?.Dispose();
                }
            }
            Disposed = true;
        }
    }
}
