using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Contracts;

namespace RealEstate.Core.ViewModels.Clients
{
    public class ClientViewModel
    {
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
