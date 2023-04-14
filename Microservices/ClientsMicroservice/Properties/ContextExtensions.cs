using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.ServiceExtensions;

namespace ClientsMicroservice.Properties
{
    public static class ContextExtensions
    {
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
    }
}
