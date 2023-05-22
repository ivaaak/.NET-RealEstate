#nullable disable
using RealEstate.Shared.Models.DTOs.Clients;

namespace RealEstate.Shared.EventBus.Events
{
    public class ClientEvent : IntegrationBaseEvent
    {
        public ClientDTO Client { get; set; }
    }
}
