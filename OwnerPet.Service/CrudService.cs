using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OwnerPet.Data.Infrastructure;
using OwnerPet.Data.Repositories;
using OwnerPet.Infrastructure.Extensions;
using OwnerPet.Infrastructure.Pagination;
using OwnerPet.Model;
using OwnerPet.Service.Interfaces;

namespace OwnerPet.Service
{
    public abstract class CrudService<TEntity, TKey> : ICrudService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected IRepository<TEntity, TKey> Repository { get; set; }
        protected IUnitOfWork Database { get; set; }

        protected CrudService(IRepository<TEntity, TKey> repository, IUnitOfWork database)
        {
            Repository = repository;
            Database = database;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetAllDbEntities().ToList();
        }

        public virtual PaginationSet<TEntity> GetPart(PaginationSetRequest request)
        {
            return GetPart(request, null);
        }

        public virtual PaginationSet<TEntity> GetPart(PaginationSetRequest request,
            Expression<Func<TEntity, bool>> predicate)
        {
            request.Validate();

            var query = predicate != null ? Where(predicate) : GetAllDbEntities();

            //todo: It is not sorted by int:ID, need to fix
            query = query.OrderBy(request.OrderBy, request.Descending);

            var offset = (request.PageIndex - 1) * request.PageSize;
            var batch = query.GetBatch(offset, request.PageSize);

            if (batch.Status != BatchStatus.Full)
                return PaginationSet<TEntity>.Empty;

            return new PaginationSet<TEntity>
            {
                Page = request.PageIndex,
                TotalCount = batch.TotalRecordCount,
                TotalPages = (int)Math.Ceiling((decimal)batch.TotalRecordCount / request.PageSize),
                Items = batch.Items
            };
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Where(predicate);
        }

        protected virtual IQueryable<TEntity> GetAllDbEntities()
        {
            return Repository.GetAll();
        }

        public virtual async Task<TKey> Create(TEntity entity)
        {
            Repository.Add(entity);
            await SaveAsync();
            return entity.Id;
        }

        public virtual async Task Delete(TKey key)
        {
            var user = await Repository.FindAsync(key);
            Repository.Remove(user);
            await SaveAsync();
        }

        public virtual async Task SaveAsync()
        {
            await Database.CommitAsync();
        }
    }
}
