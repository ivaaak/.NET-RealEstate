using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.Data.Repository;

namespace RealEstate.Shared.CrossCutting.ServiceExtensions
{
    public static class ServiceFactoryExtension
    {
        public static IServiceCollection AddServicesFactory(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddTransient<IEmailService, EmailService>();
            //services.AddTransient<IAuth0Service, Auth0Service>();
            //services.AddTransient<ICacheService, CacheService>();
            //services.AddTransient<IEstateService, EstateService>();
            //services.AddTransient<IFileUploadService, FileUploadService>();
            //services.AddTransient<IListingService, ListingService>();
            //services.AddTransient<INotificationService, NotificationService>();
            //services.AddTransient<IJsonSerializer, JsonSerializer>();
            //services.AddTransient<ISortingService, EstateSortingService>();

            return services;
        }
    }
}
