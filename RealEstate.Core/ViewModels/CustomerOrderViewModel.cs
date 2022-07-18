using RealEstate.Infrastructure.Data;

namespace RealEstate.Core.ViewModels
{

    public class CustomerOrderViewModel
    {
        public string? CustomerNumber { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
