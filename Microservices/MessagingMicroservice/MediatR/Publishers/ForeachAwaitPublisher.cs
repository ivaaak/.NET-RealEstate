using MediatR;

namespace MessagingMicroservice.MediatR.Publishers
{
    public class ForeachAwaitPublisher : INotificationPublisher
    {
        public async Task Publish(
            IEnumerable<NotificationHandlerExecutor> handlerExecutors,
            INotification notification,
            CancellationToken cancellationToken)
        {
            foreach (var handler in handlerExecutors)
            {
                await handler
                    .HandlerCallback(notification, cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}
