using Hangfire;
using MessagingMicroservice.Data.Repository;
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
    }
}
