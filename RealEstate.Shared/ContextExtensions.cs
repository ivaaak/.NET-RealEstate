using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared
{
    public class ContextExtensions
    {
        public static void SetupContexts(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // get a reference to the services provided by the host
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                // get a reference to the DbContext instances
                var clientsDbContext = services.GetRequiredService<ClientsDBContext>();
                var contractsDbContext = services.GetRequiredService<ContractsDBContext>();
                var estatesDbContext = services.GetRequiredService<EstatesDBContext>();
                var identityUsersDbContext = services.GetRequiredService<IdentityUsersDBContext>();
                var listingsDbContext = services.GetRequiredService<ListingsDBContext>();

                // apply any pending migrations
                clientsDbContext.Database.Migrate();
                contractsDbContext.Database.Migrate();
                estatesDbContext.Database.Migrate();
                identityUsersDbContext.Database.Migrate();
                listingsDbContext.Database.Migrate();
            }

            // start the host
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<ClientsDBContext>(options =>
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("ClientsDBConnection")));
                    services.AddDbContext<ContractsDBContext>(options =>
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("ContractsDBConnection")));
                    services.AddDbContext<EstatesDBContext>(options =>
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("EstatesDBConnection")));
                    services.AddDbContext<IdentityUsersDBContext>(options =>
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("IdentityUsersDBConnection")));
                    services.AddDbContext<ListingsDBContext>(options =>
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("ListingsDBConnection")));
                });

    }
}
