using Hangfire;
using MediatR.NotificationPublishers;
using MessagingMicroservice.Data.Repository;
using MessagingMicroservice.MediatR.Notifications.Estates;
using MessagingMicroservice.Services.Email;
using MessagingMicroservice.Services.Notification;
using RealEstate.Shared.Data.Repository;

namespace MessagingMicroservice.Properties
{
    public static class MessagingStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services)
        {
            // Register the required services
            services.AddTransient<INotificationService, NotificationService>();
            services.AddSingleton<IBackgroundJobClient>(provider => new BackgroundJobClient(Hangfire.JobStorage.Current));


            // Services
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<INotificationService, NotificationService>();

            // Repositories
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }


        public static IServiceCollection AddMediatRNotificationsConfigured(this IServiceCollection services)
        {
            services.AddMediatR(config => {
                config.RegisterServicesFromAssemblyContaining<EstateNotification>();

                // Setting the publisher directly will make the instance a Singleton.
                config.NotificationPublisher = new TaskWhenAllPublisher();

                // Seting the publisher type will:
                // 1. Override the value set on NotificationPublisher
                // 2. Use the service lifetime from the ServiceLifetime property below
                config.NotificationPublisherType = typeof(TaskWhenAllPublisher);

                config.Lifetime = ServiceLifetime.Transient;
            });

            return services;
        }
    }
}
