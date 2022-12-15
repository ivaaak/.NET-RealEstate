using AutoMapper;
using RealEstate.Infrastructure.Mapping;
using RealEstate.Models.Entities.Clients;

namespace RealEstate.Infrastructure.LookupModels
{
    public class ClientSelectLookupModel : IMapFrom<Client>, IHasCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Client, ClientSelectLookupModel>();
        }
    }
}
