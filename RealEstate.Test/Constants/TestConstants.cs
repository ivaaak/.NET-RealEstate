using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Contracts;

namespace RealEstate.Test.Constants
{
    public class TestConstants
    {
        public static Client client = new Client()
        {
            Id = "1",
            Client_Id = "1",
            Client_Address = "ul. Hubavka",
            Client_Details = "details placeholder",
            Client_Name = "Giga Chikadze",
            Email = "",
            Mobile = "088",
            Phone = "02",
        };

        public static Contact contact = new Contact() { };

        public static Contract contract = new Contract() { };

        public static Contract_Invoice contract_invoice = new Contract_Invoice() { };

        public static Contract_Type contract_type = new Contract_Type() { };

        public static Payment_Frequency payment_frequency = new Payment_Frequency() { };

        public static Under_Contract under_contract = new Under_Contract() { };

    }
}
