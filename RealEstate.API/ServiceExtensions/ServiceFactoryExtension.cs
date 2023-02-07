using RealEstate.API.Authentication;
using RealEstate.API.Authentication.Contracts;
using RealEstate.Data.Repository;
using RealEstate.Microservices.Email;
using RealEstate.Microservices.Estates;
using RealEstate.Microservices.Listings;
using RealEstate.Microservices.Notification;
using RealEstate.Microservices.Sorting;
using RealEstate.Microservices.Utils.Cache;
using RealEstate.Microservices.Utils.FileUpload;
using RealEstate.Microservices.Utils.Serializer;

namespace RealEstate.API.ServiceExtensions
{
    public static class ServiceFactoryExtension
    {
        public static IServiceCollection AddServicesFactory(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuth0Service, Auth0Service>();
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<IEstateService, EstateService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IListingService, ListingService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();
            services.AddTransient<ISortingService, EstateSortingService>();


            return services;
        }
    }
}
