#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Contracts
{
    public class Contract : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Client_Id")]
        public string Client_Id { get; set; }
        public Client Client { get; set; }

        public string Employee_Id { get; set; }

        public int Contract_Type_Id { get; set; }

        public string Contract_Details { get; set; }

        public int Payment_Frequency_Id { get; set; }

        public int Number_Of_Invoices { get; set; }

        public decimal Payment_Amount { get; set; }

        public decimal Fee_Percentage { get; set; }

        public decimal Fee_Amount { get; set; }

        public DateTime Date_Signed { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public int Transaction_Id { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
