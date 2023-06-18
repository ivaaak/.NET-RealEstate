using RealEstate.Shared.Models.Entities.Clients;

namespace MessagingMicroservice.MediatR.Notifications.Estates
{

    public class ClientNotification : MediatRNotificationBase
    {
        // MediatRNotificationBase - Id, DateCreated, DateUpdated, HasBeenSent
        public Client? Client { get; set; }

        public Contact? Contact { get; set; }
    }
}
