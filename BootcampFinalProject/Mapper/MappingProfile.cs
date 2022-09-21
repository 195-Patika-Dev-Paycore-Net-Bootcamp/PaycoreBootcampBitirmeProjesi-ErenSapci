using AutoMapper;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;

namespace BootcampFinalProject.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<OfferDto, Offer>().ReverseMap();
            CreateMap<Offer, OfferDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<MailDto, Mail>().ReverseMap();

            // UpdateRequest -> User
            CreateMap<UserDto, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }));
            CreateMap<AuthenticateResponse, User>().ReverseMap();

        }

    }
}
