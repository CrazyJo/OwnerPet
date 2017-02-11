using OwnerPet.Infrastructure.Pagination;

namespace OwnerPet.Web.Models
{
    public class PetsRequest : PaginationSetRequest
    {
        public int OwnerId { get; set; }
    }
}