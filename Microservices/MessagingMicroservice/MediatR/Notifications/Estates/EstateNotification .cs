using RealEstate.Shared.Models.Entities.Estates;

namespace MessagingMicroservice.MediatR.Notifications.Estates
{

    public class EstateNotification : MediatRNotificationBase
    {
        // MediatRNotificationBase - Id, DateCreated, DateUpdated, HasBeenSent
        public Estate? Estate { get; set; }
    }
}
