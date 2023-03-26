using ListingsMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RealEstate.Shared.CrossCutting.ServiceExtensions;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace ListingsMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IRepository, Repository>();
            //services.AddScoped<IUserService, UserService>();
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

        public static IServiceCollection AddSwaggerWithConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Listings APIs Microservice",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            return services;
        }
    }
}
