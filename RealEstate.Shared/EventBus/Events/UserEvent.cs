#nullable disable
using RealEstate.Shared.Models.DTOs.Users;

namespace RealEstate.Shared.EventBus.Events
{
    public class UserEvent : IntegrationBaseEvent
    {
        public UserDto User { get; set; }
    }
}
