using System;

namespace OwnerPet.Infrastructure.Pagination
{
    public class PaginationSetRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        /// <summary>
        /// Name of the property to sort
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Sort by ascending or descending order.
        /// </summary>
        public bool Descending { get; set; }


        public PaginationSetRequest()
        {
            PageSize = 3;
            PageIndex = 1;
            OrderBy = "Name";
            Descending = false;
        }

        public void Validate()
        {
            if (PageSize < 1)
                throw new InvalidOperationException("Page size must be greater than zero.");
            if (PageIndex < 1)
                throw new InvalidOperationException("Page index must be greater than zero.");
        }
    }
}
