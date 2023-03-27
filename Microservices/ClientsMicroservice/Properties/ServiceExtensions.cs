using ClientsMicroservice.Authentication;
using ClientsMicroservice.Authentication.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.ServiceExtensions;

namespace ClientsMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository), typeof(Repository));
            services.AddScoped(typeof(IApplicationDbRepository), typeof(ApplicationDbRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Clients_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var estatesConnectionString = EnvironmentConfig.Current.PostgreEstatesConnection;

            // Microdatabases
            services.AddDbContext<ClientsDBContext>(options => options.UseNpgsql(estatesConnectionString));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddSwaggerWithConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Clients Microservice",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            return services;
        }
    }
}
