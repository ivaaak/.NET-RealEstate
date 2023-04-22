using AutoMapper;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.DTOs.Users;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;
using RealEstate.Shared.Models.Entities.Users;

namespace RealEstate.Shared.Models.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Estate, EstateDTO>();
            CreateMap<Listing, ListingDTO>();
            //CreateMap<SearchQuery, SearchViewModel>();

        // USERS
            // UserEntity -> UserResponse
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserAttribute, AttributeDto>().ReverseMap();

            //CreateUserRequest -> UserEntity
            //CreateMap<CreateUserCommand, KeycloakUserEntity>();
        }
    }
}
