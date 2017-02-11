using System.Collections.Generic;
using System.Linq;

namespace OwnerPet.Infrastructure.Pagination
{
    public class PaginationSet<T>
    {
        public static PaginationSet<T> Empty { get; }

        static PaginationSet()
        {
            Empty = new PaginationSet<T>
            {
                Page = 0,
                TotalCount = 0,
                TotalPages = 0,
                Items = Enumerable.Empty<T>().ToList()
            };
        }
        
        public int Page { get; set; }
        public int Count => Items?.Count() ?? 0;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}