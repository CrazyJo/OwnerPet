using AutoMapper;
using OwnerPet.Infrastructure.Pagination;
using OwnerPet.Model;
using OwnerPet.Web.Models;

namespace OwnerPet.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.PetsCount, opt => opt.MapFrom(src => src.Pets.Count));
            CreateMap<PaginationSet<User>, PaginationSet<UserViewModel>>();
            CreateMap<Pet, PetViewModel>();
            CreateMap<PaginationSet<Pet>, PaginationSet<PetViewModel>>();
        }
    }
}