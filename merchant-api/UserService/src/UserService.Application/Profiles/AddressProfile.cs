using AutoMapper;
using UserService.Application.Dtos.Users;
using UserService.Domain.Entities.Concretes;

namespace UserService.Application.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<UserAddress, UserAddressDto>()
              .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address));

        CreateMap<UserAddressDto, UserAddress>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Street));
    }
}
