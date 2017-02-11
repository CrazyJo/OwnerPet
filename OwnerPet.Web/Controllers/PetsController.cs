using System.Web.Http;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OwnerPet.Infrastructure.Pagination;
using OwnerPet.Model;
using OwnerPet.Service.Interfaces;
using OwnerPet.Web.Models;

namespace OwnerPet.Web.Controllers
{
    public class PetsController : BaseController<Pet, PetViewModel, int>
    {

        public PetsController(IPetService petService) : base(petService)
        {
        }


        public IHttpActionResult Get([FromUri]int ownerId, [FromUri] PaginationSetRequest petsRequest)
        {
            if (petsRequest == null) return BadRequest();
            var domainModel = ApiService.GetPart(petsRequest, p => p.OwnerId == ownerId);
            if (domainModel == PaginationSet<Pet>.Empty)
                return NotFound();
            var viewModel = Mapper.Map<PaginationSet<PetViewModel>>(domainModel);
            return Json(viewModel, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
