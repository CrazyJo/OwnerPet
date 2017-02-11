using System;
using System.Collections.Generic;

namespace OwnerPet.Infrastructure.Pagination
{
    public class Batch<T>
    {
        public BatchStatus Status { get; set; }
        public int TotalRecordCount { get; set; }
        public IEnumerable<T> Items { get; set; }
        public Exception Exception { get; set; }
    }
}
