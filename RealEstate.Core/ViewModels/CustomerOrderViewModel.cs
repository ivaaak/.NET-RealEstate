using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.Core.ViewModels
{

    public class CustomerOrderViewModel
    {
        public string? CustomerNumber { get; set; }

        public List<Estate> Properties { get; set; } = new List<Estate>();
    }
}
