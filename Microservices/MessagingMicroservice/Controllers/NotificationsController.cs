using Microsoft.AspNetCore.Mvc;

namespace MessagingMicroservice.Controllers
{
    public class NotificationsController : ControllerBase
    {
        /*
        private readonly INotificationRepository _notificationRepository;

        public NotificationsController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CreateNotificationResponse>> CreateNotification(CreateNotificationRequest request)
        {
            // Validate the request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create the notification object
            var notification = new Notification
            {
                UserId = request.UserId,
                Type = request.Type,
                Title = request.Title,
                Message = request.Message,
                ScheduledDate = request.ScheduledDate,
                CreatedDate = DateTime.UtcNow
            };

            // Save the notification to the repository
            await _notificationRepository.AddAsync(notification);

            // Return the response
            return new CreateNotificationResponse
            {
                NotificationId = notification.Id
            };
        }

        [HttpGet]
        public async Task<ActionResult<GetNotificationsResponse>> GetNotifications(string userId)
        {
            // Get the notifications for the specified user
            var notifications = await _notificationRepository.GetByUserIdAsync(userId);

            // Return the response
            return new GetNotificationsResponse
            {
                Notifications = notifications.Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Type = n.Type,
                    Title = n.Title,
                    ScheduledDate = n.ScheduledDate
                }).ToList()
            };
        }

        [HttpDelete("{notificationId}")]
        public async Task<ActionResult<DeleteNotificationResponse>> DeleteNotification(string notificationId)
        {
            // Get the notification
            var notification = await _notificationRepository.GetByIdAsync(notificationId);
            if (notification == null)
            {
                return NotFound();
            }

            // Delete the notification from the repository
            await _notificationRepository.DeleteAsync(notification);

            // Return the response
            return new DeleteNotificationResponse
            {
                NotificationId = notification.Id
            };
        }
        */
    }
}