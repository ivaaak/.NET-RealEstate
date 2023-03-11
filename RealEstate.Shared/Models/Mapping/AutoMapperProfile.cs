using AutoMapper;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Models.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Estate, EstateDTO>();
            CreateMap<Listing, ListingDTO>();
            CreateMap<Estate, EstateDTO>();
            CreateMap<Estate, EstateDTO>();
            //CreateMap<SearchQuery, SearchViewModel>();
        }
    }
}


/*
The RealEstateProfile class extends the Profile class from the AutoMapper namespace and contains two 
CreateMap methods that specify the source and destination types for the mapping. In this case, 
the RealEstate entity is mapped to the RealEstateViewModel view model and vice versa.

After creating the mapping profile, you need to register it with the AutoMapper configuration. 
This can be done in the ConfigureServices method of the Startup.cs file:
*/