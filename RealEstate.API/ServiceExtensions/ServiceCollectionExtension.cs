using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;
using RealEstate.Data.Repository;
using RealEstate.Microservices.Auth0;
using RealEstate.Microservices.Cache;
using RealEstate.Microservices.Email;
using RealEstate.Microservices.Estates;
using RealEstate.Microservices.FileUpload;
using RealEstate.Microservices.Listings;
using RealEstate.Microservices.Notification;
using RealEstate.Microservices.Serializer;
using RealEstate.Microservices.Sorting;
using RealEstate.Microservices.Users;

namespace RealEstate.API.ServiceExtensions
{
    public static class ServiceCollectionExtension
    {
        //PostgreSQL Server connection string
        private static string PostgreSQLConnectionString = @"Host=127.0.0.1;Database=RealEstate;Username=postgres;Password=admin";

        // Microsoft SQL Server connection string (SQL Express Server)
        private static string MySQLConnectionString = @"Server=DESKTOP-6PR2R6Q\SQLEXPRESS01;Database=RealEstate;Trusted_Connection=True";

        public static IServiceCollection AddServicesFactory(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuth0AuthenticationService, Auth0AuthenticationService>();
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<IEstateService, EstateService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IListingService, ListingService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();
            services.AddTransient<ISortingService, EstateSortingService>();


            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Context(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(PostgreSQLConnectionString));
            services.AddDbContext<ClientsDBContext>(options => options.UseNpgsql(PostgreSQLConnectionString));
            services.AddDbContext<ContractsDBContext>(options => options.UseNpgsql(PostgreSQLConnectionString));
            services.AddDbContext<EstatesDBContext>(options => options.UseNpgsql(PostgreSQLConnectionString));
            services.AddDbContext<ListingsDBContext>(options => options.UseNpgsql(PostgreSQLConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection Use_MicrosoftSQL_Context(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(MySQLConnectionString));
            services.AddDbContext<ClientsDBContext>(options => options.UseSqlServer(MySQLConnectionString));
            services.AddDbContext<ContractsDBContext>(options => options.UseSqlServer(MySQLConnectionString));
            services.AddDbContext<EstatesDBContext>(options => options.UseSqlServer(MySQLConnectionString));
            services.AddDbContext<ListingsDBContext>(options => options.UseSqlServer(MySQLConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
