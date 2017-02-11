using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
    public abstract class BaseController<TDomain, TVm, TKey> : ApiController
        where TVm : ICreature<TKey>, new()
        where TDomain : IEntity<TKey>
    {
        protected ICrudService<TDomain, TKey> ApiService { get; set; }

        protected BaseController(ICrudService<TDomain, TKey> apiService)
        {
            ApiService = apiService;
        }

        public virtual IHttpActionResult Get([FromUri] PaginationSetRequest paginationSetRequest)
        {
            if (paginationSetRequest == null) return BadRequest();
            var domainModel = ApiService.GetPart(paginationSetRequest);
            if (domainModel == PaginationSet<TDomain>.Empty)
                return NotFound();
            var viewModel = Mapper.Map<PaginationSet<TVm>>(domainModel);
            return Json(viewModel, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public virtual async Task<IHttpActionResult> Post([FromBody]TVm viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Name))
                ModelState.AddModelError($"viewModel.{nameof(viewModel.Name)}", "Empty");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var domainModel = Mapper.Map<TDomain>(viewModel);
                var id = await ApiService.Create(domainModel);
                viewModel.Id = id;
                Debug.WriteLine($"POST {id}");
                return Created(Request.RequestUri.AbsoluteUri + id, viewModel);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public virtual async Task<IHttpActionResult> Delete(TKey id)
        {
            try
            {
                Debug.WriteLine($"Delete {id}");

                await ApiService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
