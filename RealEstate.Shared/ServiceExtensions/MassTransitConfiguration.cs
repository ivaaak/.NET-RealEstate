using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.EventBus;
using RealEstate.Shared.EventBus.Consumers;

namespace RealEstate.Shared.ServiceExtensions
{
    public static class MassTransitConfiguration
    {
        // RabbitMQ MassTransit
        public static IServiceCollection AddMassTransitWithRabbitMQProvider(this IServiceCollection services)
        {
            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, rabbit) => {
                    rabbit.Host(GlobalConnectionStrings.RabbitMQ_Connection);
                    rabbit.ConfigureEndpoints(ctx);
                });
            });
            // services.AddMassTransitHostedService();

            return services;
        }

        public static IServiceCollection AddMassTransitEstateConsumer(this IServiceCollection services)
        {
            services.AddMassTransit(config => {
                config.AddConsumer<EstateConsumer>();

                config.UsingRabbitMq((ctx, rabbit) => {
                    rabbit.Host(GlobalConnectionStrings.RabbitMQ_Connection);
                    rabbit.ConfigureEndpoints(ctx);

                    rabbit.ReceiveEndpoint(EventBusConstants.EstatesQueue, c => { //string ReceiveEndpointName
                        c.ConfigureConsumer<EstateConsumer>(ctx);
                    });
                });
            });

            return services;
        }
         
        // Add more consumers below
    }
}
