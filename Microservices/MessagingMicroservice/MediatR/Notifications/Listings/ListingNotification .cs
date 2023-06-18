using RealEstate.Shared.Models.Entities.Listings;

namespace MessagingMicroservice.MediatR.Notifications.Estates
{

    public class ListingNotification : MediatRNotificationBase
    {
        // MediatRNotificationBase - Id, DateCreated, DateUpdated, HasBeenSent
        public Address? Address { get; set; }

        public Agency? Agency { get; set; }

        public Agent? Agent { get; set; }

        public Comment? Comment { get; set; }

        public Company? Company { get; set; }

        public Employee? Employee { get; set; }

        public Listing? Listing { get; set; }

        public ListingStats? ListingStats { get; set; }

        public PriceHistory? PriceHistory { get; set; }

        public Review? Review { get; set; }
    }
}
