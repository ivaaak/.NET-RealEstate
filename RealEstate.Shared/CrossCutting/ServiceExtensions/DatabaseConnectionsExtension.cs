using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.CrossCutting.ServiceExtensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection Use_PostgreSQL_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var identityPostgreConnectionString = EnvironmentConfig.Current.PostgreIdentityConnection;
            var estatesConnectionString = EnvironmentConfig.Current.PostgreEstatesConnection;
            var listingsConnectionString = EnvironmentConfig.Current.PostgreListingsConnection;
            var contractsConnectionString = EnvironmentConfig.Current.PostgreContractsConnection;
            var clientsConnectionString = EnvironmentConfig.Current.PostgreClientsConnection;

            var mainPostgreConnectionString = EnvironmentConfig.Current.PostgreSQLMainConnection;


            services.AddDbContext<_CombinedContext>(options => options.UseNpgsql(mainPostgreConnectionString));
            // Microdatabases
            services.AddDbContext<IdentityUsersDBContext>(options => options.UseNpgsql(identityPostgreConnectionString));
            services.AddDbContext<ClientsDBContext>(options => options.UseNpgsql(clientsConnectionString));
            services.AddDbContext<ContractsDBContext>(options => options.UseNpgsql(contractsConnectionString));
            services.AddDbContext<EstatesDBContext>(options => options.UseNpgsql(estatesConnectionString));
            services.AddDbContext<ListingsDBContext>(options => options.UseNpgsql(listingsConnectionString));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection Use_MicrosoftSQL_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var mySQLConnectionString = EnvironmentConfig.Current.MySQLMainConnection;

            services.AddDbContext<_CombinedContext>(options => options.UseSqlServer(mySQLConnectionString));
            services.AddDbContext<ClientsDBContext>(options => options.UseSqlServer(mySQLConnectionString));
            services.AddDbContext<ContractsDBContext>(options => options.UseSqlServer(mySQLConnectionString));
            services.AddDbContext<EstatesDBContext>(options => options.UseSqlServer(mySQLConnectionString));
            services.AddDbContext<ListingsDBContext>(options => options.UseSqlServer(mySQLConnectionString));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
