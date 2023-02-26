using RealEstate.Models.Entities.Clients;
using RealEstate.Models.Entities.Contracts;

namespace RealEstate.Models.DTOs.Clients
{
    public class ClientEditDTO
    {
        //TODO add validations/annotations
        public string Client_Id { get; init; }

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
    }
}
