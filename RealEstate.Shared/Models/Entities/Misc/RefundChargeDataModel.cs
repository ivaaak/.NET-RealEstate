#nullable disable
namespace RealEstate.Shared.Models.Entities.Misc
{
    public class RefundChargeDataModel
    {
        public string ChargeId { get; set; }

        public long Amount { get; set; }

        public string Reason { get; set; }
    }
}
