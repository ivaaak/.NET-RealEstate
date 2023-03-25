using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RealEstate.ApiGateway.ServiceExtensions;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace ContractsMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository), typeof(Repository));
            services.AddScoped(typeof(IApplicationDbRepository), typeof(ApplicationDbRepository));
            //services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Contracts_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var estatesConnectionString = EnvironmentConfig.Current.PostgreEstatesConnection;

            // Microdatabases
            services.AddDbContext<ContractsDBContext>(options => options.UseNpgsql(estatesConnectionString));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddSwaggerWithConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Contracts Microservice",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            return services;
        }
    }
}
