namespace RealEstate.Microservices.Notification
{
    public interface INotificationService
    {
        // SEND NOTIFICATION
        void SendNotification(string email, string message);

        // SCHEDULE NOTIFICATION
        void ScheduleNotification(string email, string message, DateTime time);
    }
}
