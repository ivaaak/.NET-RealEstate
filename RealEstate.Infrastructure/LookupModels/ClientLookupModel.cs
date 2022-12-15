using RealEstate.Infrastructure.Mapping;
using RealEstate.Models.Entities.Clients;

namespace RealEstate.Infrastructure.LookupModels
{
    public class ClientLookupModel : IMapFrom<Client>
    {
        public string Client_Id { get; init; }

        public string Client_Name { get; set; }

        public string Client_Address { get; set; }

        public string Contact_Person { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string EMail { get; set; }

        public string Client_Details { get; set; }

        public DateTime Time_Created { get; init; }

        public Contact Contact { get; set; }
    }
}
