using RealEstate.Infrastructure.Entities;

namespace RealEstate.Core.ViewModels
{

    public class CustomerOrderViewModel
    {
        public string? CustomerNumber { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
