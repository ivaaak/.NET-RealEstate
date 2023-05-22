using MassTransit;
using Microsoft.Extensions.Logging;
using RealEstate.Shared.EventBus.Events;

namespace RealEstate.Shared.EventBus.Consumers
{
    public class ListingConsumer : IConsumer<ListingEvent>
    {
        private readonly ILogger<ListingConsumer> _logger;

        public ListingConsumer(ILogger<ListingConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ListingEvent> context)
        {
            var listingName = context.Message.Listing.Name;
            var listingObject = context.Message.Listing;
            var messageId = context.MessageId;

            _logger.LogInformation($"Consumed Message: listing {listingName} {listingObject} {messageId}");

            return Task.CompletedTask;
        }
    }
}
