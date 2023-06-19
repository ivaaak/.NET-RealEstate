using MediatR;

namespace MessagingMicroservice.MediatR.Publishers
{
    public class TaskWhenAllPublisher : INotificationPublisher
    {
        public Task Publish(
            IEnumerable<NotificationHandlerExecutor> handlerExecutors,
            INotification notification,
            CancellationToken cancellationToken)
        {
            var tasks = handlerExecutors
                .Select(handler => handler.HandlerCallback(
                    notification,
                    cancellationToken))
                .ToArray();

            return Task.WhenAll(tasks);
        }
    }
}
