using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OwnerPet.Data.Infrastructure;
using OwnerPet.Model;
using System.Data.Entity.Infrastructure;


namespace OwnerPet.Data.Repositories
{
    public class EntityRepository<TEntity, TKey> : IDisposable, IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected DbSet<TEntity> DbSet { get; set; }
        protected DbContext DbContextInstance { get; set; }
        protected bool Disposed { get; set; }

        public EntityRepository(IDbFactory factory)
        {
            DbContextInstance = factory.GetContext();
            DbSet = DbContextInstance.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties.Aggregate(DbSet, (Func<IQueryable<TEntity>, Expression<Func<TEntity, object>>, IQueryable<TEntity>>)((current, includeProperty) => current.Include(includeProperty)));
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual TEntity Add(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContextInstance.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return DbSet.AddRange(entities);
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await FindAsync(CancellationToken.None, keyValues);
        }

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await DbSet.FindAsync(cancellationToken, keyValues);
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return DbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
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
                    DbContextInstance?.Dispose();
                }
            }
            Disposed = true;
        }
    }
}
