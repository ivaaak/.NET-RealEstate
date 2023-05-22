#nullable disable
using RealEstate.Shared.Models.DTOs.Estates;

namespace RealEstate.Shared.EventBus.Events
{
    public class EstateEvent : IntegrationBaseEvent
    {
        public EstateDTO Estate { get; set; }
    }
}
