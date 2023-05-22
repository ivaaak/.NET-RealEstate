using MassTransit;
using Microsoft.Extensions.Logging;
using RealEstate.Shared.EventBus.Events;

namespace RealEstate.Shared.EventBus.Consumers
{
    public class EstateConsumer : IConsumer<EstateEvent>
    {
        private readonly ILogger<EstateConsumer> _logger;

        public EstateConsumer(ILogger<EstateConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<EstateEvent> context)
        {
            var estateName = context.Message.Estate.Estate_Name; 
            var estateObject = context.Message.Estate;
            var messageId = context.MessageId;

            _logger.LogInformation($"Consumed Message: estate {estateName} {estateObject} {messageId}");

            // 
            return Task.CompletedTask;
        }
    }
}
