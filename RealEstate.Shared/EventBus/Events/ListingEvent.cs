#nullable disable
using RealEstate.Shared.Models.DTOs.Listings;

namespace RealEstate.Shared.EventBus.Events
{
    public class ListingEvent : IntegrationBaseEvent
    {
        public ListingDTO Listing { get; set; }
    }
}
