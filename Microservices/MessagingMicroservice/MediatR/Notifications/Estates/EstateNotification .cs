using RealEstate.Shared.Models.Entities.Estates;

namespace MessagingMicroservice.MediatR.Notifications.Estates
{

    public class EstateNotification : MediatRNotificationBase
    {
        // MediatRNotificationBase - Id, DateCreated, DateUpdated, HasBeenSent
        public Estate? Estate { get; set; }

        public Category? Category { get; set; }

        public City? City { get; set; }

        public Country? Country { get; set; }

        public Estate_Status? Estate_Status { get; set; }

        public Estate_Type? Estate_Type { get; set; }

        public In_Charge? In_Charge { get; set; }
    }
}
