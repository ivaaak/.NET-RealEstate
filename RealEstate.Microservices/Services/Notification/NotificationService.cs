using Hangfire;
using RealEstate.Microservices.Contracts;

namespace RealEstate.Microservices.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;

        private readonly IBackgroundJobClient _backgroundJobClient;


        public NotificationService(
            IEmailService emailService,
            IBackgroundJobClient backgroundJobClient)
        {
            _emailService = emailService;
            _backgroundJobClient = backgroundJobClient;
        }

        // SEND NOTIFICATION
        public void SendNotification(string email, string message)
        {
            // Send the email using the IEmailService instance.
            _emailService.SendEmailAsync(email, "Notification", message, "");
        }

        // SCHEDULE NOTIFICATION
        public void ScheduleNotification(string email, string message, DateTime time)
        {
            // Use the IBackgroundJobClient instance to schedule the SendNotification method.
            _backgroundJobClient.Schedule(() => SendNotification(email, message), time);
        }
    }
}
