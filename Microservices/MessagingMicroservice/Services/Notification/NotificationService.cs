using Hangfire;
using MediatR; //Masstransir.MediatR ??

namespace MessagingMicroservice.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IMediator _mediator;

        private readonly IBackgroundJobClient _backgroundJobClient;


        public NotificationService(
            IMediator mediator,
            IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

    }
}
