using AutoMapper;
using RealEstate.Core.Mapping;
using RealEstate.Infrastructure.Entities.Clients;

namespace RealEstate.Core.LookupModels
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
