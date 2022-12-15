using AutoMapper;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Clients;
using RealEstate.Models.ViewModels.Estates;
using RealEstate.Models.ViewModels.Listings;

namespace RealEstate.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<Estate, EstateViewModel>();
            CreateMap<Listing, ListingViewModel>();
            CreateMap<Estate, EstateViewModel>();
            CreateMap<Estate, EstateViewModel>();
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