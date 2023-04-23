#nullable disable
namespace RealEstate.Shared.Models.Entities.Misc
{
    public class ChargeDataModel
    {
        public long Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }
    }
}
