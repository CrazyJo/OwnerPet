using AutoMapper;
using OwnerPet.Model;
using OwnerPet.Web.Models;

namespace OwnerPet.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PetViewModel, Pet>();
            //CreateMap<PetViewModel, Pet>()
            //    .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => new User(src.OwnerId)));
            CreateMap<UserViewModel, User>();
        }
    }
}