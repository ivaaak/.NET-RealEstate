using MassTransit;
using Microsoft.Extensions.Logging;
using RealEstate.Shared.EventBus.Events;

namespace RealEstate.Shared.EventBus.Consumers
{
    public class ClientConsumer : IConsumer<ClientEvent>
    {
        private readonly ILogger<ClientConsumer> _logger;

        public ClientConsumer(ILogger<ClientConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ClientEvent> context)
        {
            Console.WriteLine("Message with ID " + context.Message.Id + " received");

            var clientName = context.Message.Client.Client_Name; 
            var clientObject = context.Message.Client;
            var messageId = context.MessageId;

            _logger.LogInformation($"Consumed Message: Client {clientName} {clientObject} {messageId}");

            return Task.CompletedTask;
        }
    }
}
