using System;
using System.Linq;

namespace OwnerPet.Infrastructure.Pagination
{
    public static class Batcher
    {
        public static Batch<T> GetBatch<T>(this IQueryable<T> query, int offset, int batchCapacity)
        {
            var result = new Batch<T>();
            try
            {
                var queryRes = query.Skip(offset).Take(batchCapacity).GroupBy(r => new { Total = query.Count() }).ToList();
                if (queryRes.Count == 0)
                {
                    result.Status = BatchStatus.Empty;
                    return result;
                }
                result.TotalRecordCount = queryRes[0].Key.Total;
                result.Items = queryRes[0].ToList();
                result.Status = BatchStatus.Full;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Status = BatchStatus.Damaged;
            }
            return result;
        }
    }
}
