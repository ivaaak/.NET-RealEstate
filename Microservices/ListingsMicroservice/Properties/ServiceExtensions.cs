using ListingsMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authentication.Contracts;
using RealEstate.ApiGateway.ServiceExtensions;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace ListingsMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IListingService, ListingService>();

            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Listings_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var listingsConnectionString = EnvironmentConfig.Current.PostgreListingsConnection;

            // Microdatabases
            services.AddDbContext<ListingsDBContext>(options => options.UseNpgsql(listingsConnectionString));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
