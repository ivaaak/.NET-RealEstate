using RealEstate.Infrastructure.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Infrastructure.Entities.Clients
{
    public class Contact : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        [ForeignKey("Client_Id")]
        public int Client_Id { get; init; }

        public int Employee_Id { get; init; }

        public int Estate_Id { get; init; }

        public DateTime Contact_Time { get; init; }

        public string Contact_Details { get; init; }

        public Client Client { get; init; }



        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
