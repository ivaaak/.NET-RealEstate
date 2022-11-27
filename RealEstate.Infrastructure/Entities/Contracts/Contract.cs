using RealEstate.Infrastructure.Entities.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Infrastructure.Entities.Contracts
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client_Id")]
        public int Client_Id { get; set; }
        public Client Client { get; set; }

        public int Employee_Id { get; set; }

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
    }
}
