using System;
using System.Data.Entity;

namespace OwnerPet.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DbContext GetContext();
    }
}
