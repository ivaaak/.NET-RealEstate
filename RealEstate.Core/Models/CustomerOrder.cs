using RealEstate.Infrastructure.Data;

namespace RealEstate.Core.Models
{

    public class CustomerOrder
    {
        public string? CustomerNumber { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
