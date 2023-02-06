using EstatesMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Authentication;
using RealEstate.API.Authentication.Contracts;
using RealEstate.API.ServiceExtensions;
using RealEstate.Data.Context;
using RealEstate.Data.Repository;

namespace EstatesMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEstateService, EstateService>();

            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Estates_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var estatesConnectionString = EnvironmentConfig.Current.PostgreEstatesConnection;

            // Microdatabases
            services.AddDbContext<EstatesDBContext>(options => options.UseNpgsql(estatesConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
