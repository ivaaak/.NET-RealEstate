using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Misc;

namespace MessagingMicroservice.MediatR.Notifications.Estates
{

    public class ContractNotification : MediatRNotificationBase
    {
        // MediatRNotificationBase - Id, DateCreated, DateUpdated, HasBeenSent
        public Checklist? Checklist { get; set; }

        public DocumentModel? DocumentModel { get; set; }

        public Note? Note { get; set; }

        public Offer? Offer { get; set; }

        public Project? Project { get; set; }
    }
}
