using RealEstate.Models.Entities.Estates;

namespace RealEstate.Models.ViewModels.Contracts
{

    public class CustomerOrderViewModel
    {
        public string? Customer_Id { get; set; }

        public List<Estate> Estates { get; set; } = new List<Estate>();
    }
}
