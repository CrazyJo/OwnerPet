using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OwnerPet.Infrastructure.Pagination;

namespace OwnerPet.Service.Interfaces
{
    public interface ICrudService<TEntity, TKey>
    {
        Task<TKey> Create(TEntity item);
        IEnumerable<TEntity> GetAll();
        PaginationSet<TEntity> GetPart(PaginationSetRequest request);
        PaginationSet<TEntity> GetPart(PaginationSetRequest request, Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task Delete(TKey key);

        //void Update(TEntity obj);
    }
}
