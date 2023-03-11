using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.Models.DTOs.Contracts
{

    public class CustomerOrderViewModel
    {
        public string? Customer_Id { get; set; }

        public List<Estate> Estates { get; set; } = new List<Estate>();
    }
}
