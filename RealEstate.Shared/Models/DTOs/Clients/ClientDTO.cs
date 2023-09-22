#nullable disable
using AutoMapper;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Mapping;

namespace RealEstate.Shared.Models.DTOs.Clients
{
    public class ClientDTO : IMapFrom<Client>, IHasCustomMapping
    {
        public string Id { get; init; }

        public string Client_Name { get; init; }

        public string Client_Address { get; init; }

        public string Contact_Person { get; init; }

        public string Phone { get; init; }

        public string Mobile { get; init; }

        public string EMail { get; init; }

        public string Client_Details { get; init; }

        public DateTime Time_Created { get; init; }

        public Contact Contact { get; init; }

        public IEnumerable<Contract> Contracts { get; init; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Client, ClientDTO>();
        }
    }
}
