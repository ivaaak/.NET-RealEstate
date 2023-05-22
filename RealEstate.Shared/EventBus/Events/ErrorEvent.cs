#nullable disable
using RealEstate.Shared.Models.DTOs.Errors;

namespace RealEstate.Shared.EventBus.Events
{
    public class ErrorEvent : IntegrationBaseEvent
    {
        public ErrorDTO Error { get; set; }
    }
}
