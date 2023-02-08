<<<<<<< Updated upstream
﻿using Microsoft.EntityFrameworkCore;
=======
﻿using ListingsMicroservice.Services;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes
using RealEstate.API.Authentication;
using RealEstate.API.Authentication.Contracts;
using RealEstate.API.ServiceExtensions;
using RealEstate.Data.Context;
using RealEstate.Data.Repository;
<<<<<<< Updated upstream
using RealEstate.Microservices.Listings;
=======
>>>>>>> Stashed changes

namespace ListingsMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
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

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
