using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.Shared.Data.Context;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<ClientsDBContext>(options =>
            options.UseNpgsql(config.GetConnectionString("ClientsDBConnection")));
        services.AddDbContext<ContractsDBContext>(options =>
            options.UseNpgsql(config.GetConnectionString("ContractsDBConnection")));
        services.AddDbContext<EstatesDBContext>(options =>
            options.UseNpgsql(config.GetConnectionString("EstatesDBConnection")));
        services.AddDbContext<IdentityUsersDBContext>(options =>
            options.UseNpgsql(config.GetConnectionString("IdentityUsersDBConnection")));
        services.AddDbContext<ListingsDBContext>(options =>
            options.UseNpgsql(config.GetConnectionString("ListingsDBConnection")));
    })
    .Build();

// start the host
await host.RunAsync();