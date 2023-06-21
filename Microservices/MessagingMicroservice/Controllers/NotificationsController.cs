using MassTransit;
using MediatR;
using MessagingMicroservice.Data.Repository;
using MessagingMicroservice.MediatR.Notifications.Estates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace MessagingMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")] // api/notifications/
    public class NotificationsController : ControllerBase
    {
        
        private readonly INotificationRepository _notificationRepository;

        private readonly IMediator? _mediator;
        private readonly IPublisher? _publisher;

        private readonly ILogger<NotificationsController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationsController(
            INotificationRepository notificationRepository,
            IMediator mediator,
            IPublisher? publisher,
            ILogger<NotificationsController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));

            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        }


        // MediatR Actions
        [HttpPost]
        public async Task<IActionResult> MediatRPostEstateNotification([FromBody] Estate estate)
        {
            var notification = new EstateNotification
            {
                Estate = estate,
                NotificationMessage = $"Notification published to MediatR from the Notifications Controller"
            };

            // Publish the estate notification using MediatR
            await _mediator.Publish(notification);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MediatRPostListingNotification([FromBody] Listing listing)
        {
            var notification = new ListingNotification
            {
                Listing = listing,
                NotificationMessage = $"Notification published to MediatR from the Notifications Controller"
            };

            // Publish the estate notification using MediatR
            await _mediator.Publish(notification);

            return Ok();
        }

        // IPublisher Actions
        [HttpPost]
        public async Task<IActionResult> IPublisherPostEstateNotification([FromBody] Estate estate)
        {
            var notification = new EstateNotification
            {
                Estate = estate,
                NotificationMessage = $"Notification published to IPublisher from the Notifications Controller"
            };

            // Publish the estate notification using MediatR
            await _publisher.Publish(notification);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> IPublisherPostListingNotification([FromBody] Listing listing)
        {
            var notification = new ListingNotification
            {
                Listing = listing,
                NotificationMessage = $"Notification published to IPublisher from the Notifications Controller"
            };

            // Publish the estate notification using MediatR
            await _publisher.Publish(notification);

            return Ok();
        }


        // MassTransit Bus/Queue Actions:
        [HttpPost]
        public async Task<IActionResult> MassTransitPostEstateNotification([FromBody] Estate estate)
        {
            var notification = new EstateNotification
            {
                Estate = estate,
                NotificationMessage = $"Notification published to MassTransit PublisherEndpoint from the Notifications Controller"
            };

            // Publish the estate notification using MediatR
            await _publishEndpoint.Publish(notification);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MassTransitPostListingNotification([FromBody] Listing listing)
        {
            var notification = new ListingNotification
            {
                Listing = listing,
                NotificationMessage = $"Notification published from the Notifications Controller"
            };

            // Publish the estate notification using MediatR
            await _publishEndpoint.Publish(notification);

            return Ok();
        }
    }
}