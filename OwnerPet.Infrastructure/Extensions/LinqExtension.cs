using System;
using System.Linq;
using System.Linq.Expressions;

namespace OwnerPet.Infrastructure.Extensions
{
    public static class LinqExtension
    {
        public static Expression<Func<T, object>> GetSortLambda<T>(string propertyPath)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var parts = propertyPath.Split('.');
            Expression parent = param;
            foreach (var part in parts)
            {
                parent = Expression.Property(parent, part);
            }

            if (parent.Type.IsValueType)
            {
                var converted = Expression.Convert(parent, typeof(object));
                return Expression.Lambda<Func<T, object>>(converted, param);
            }
            return Expression.Lambda<Func<T, object>>(parent, param);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string orderBy, bool descending)
        {
            IQueryable<T> result;
            var sortExpression = GetSortLambda<T>(orderBy);
            switch (descending)
            {
                case true:
                    result = query.OrderByDescending(sortExpression);
                    break;
                default:
                    result = query.OrderBy(sortExpression);
                    break;
            }
            return result;
        }
    }
}
