using MediatR;

namespace MessagingMicroservice.MediatR.Notifications
{
    public class MediatRNotificationBase : INotification
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime? DateUpdated { get; set; }

        public bool? HasBeenPublished { get; set; }

        // Message String if needed:
        public string? NotificationMessage { get; set; }
    }
}
