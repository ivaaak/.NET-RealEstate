using global::MediatR;
using MassTransit;
using MessagingMicroservice.MediatR.Notifications.Estates;

namespace MessagingMicroservice.MediatR.Handlers.Estate
{
    public class EstateNotificationHandler : INotificationHandler<EstateNotification>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        private readonly ILogger<EstateNotificationHandler> _logger;

        public Task Handle(EstateNotification notification, CancellationToken cancellationToken)
        {
            // Handle the estate notification here
            // You can perform any necessary processing or trigger other actions based on the notification
            notification.HasBeenPublished = true;
            notification.DateUpdated = DateTime.UtcNow;

            // Go outside of the Messages Microservice
            // Publish the notification to the RabbitMQ Message Bus/Queue
            _publishEndpoint.Publish(notification);
            _logger.LogInformation($"Published notification - {notification}");

            // For example, you can log the estate details
            Console.WriteLine($"Received estate notification with ID: {notification.Id}");
            Console.WriteLine($"DateCreated: {notification.DateCreated}");
            Console.WriteLine($"Estate Details: {notification.Estate}");
            Console.WriteLine($"HasBeenPublished: {notification.HasBeenPublished}");
            Console.WriteLine($"The notification has the following text: {notification.NotificationMessage}");

            // Or you can send an email, update a database, etc.

            return Task.CompletedTask;
        }
    }
}
