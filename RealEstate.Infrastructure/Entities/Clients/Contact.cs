using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Clients
{
    public class Contact
    {
        [Key]
        public int Id { get; init; }

        public int Client_Id { get; init; }

        public int Employee_Id { get; init; }

        public int Estate_Id { get; init; }

        public DateTime Contact_Time { get; init; }

        public string Contact_Details { get; init; }
    }
}
