#nullable disable
using RealEstate.Shared.Models.DTOs.Search;

namespace RealEstate.Shared.EventBus.Events
{
    public class SearchEvent : IntegrationBaseEvent
    {
        public SearchDTO Search { get; set; }
    }
}
