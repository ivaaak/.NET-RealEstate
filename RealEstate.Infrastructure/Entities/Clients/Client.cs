using Microsoft.AspNetCore.Identity;

namespace RealEstate.Infrastructure.Entities.Clients
{
    public class Client : IdentityUser
    {
        //public override Guid Id { get; init; }

        public string Client_Name { get; init; }

        public string Client_Address { get; init; }

        public string Contact_Person { get; init; }

        public string Phone { get; init; }

        public string Mobile { get; init; }

        public string EMail { get; init; }

        public string Client_Details { get; init; }

        public DateTime Time_Created { get; init; }
    }
}
