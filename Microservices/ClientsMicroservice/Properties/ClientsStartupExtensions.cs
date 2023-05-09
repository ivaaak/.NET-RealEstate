using ClientsMicroservice.Data.Context;
using ClientsMicroservice.Data.Repository;
using ClientsMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared;
using RealEstate.Shared.Data.Repository;

namespace ClientsMicroservice.Properties
{
    public static class ClientsStartupExtensions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IUserService, UserService>();

            // DbContexts using pooling for better performance
            services.AddDbContextPool<UsersDBContext>(options => 
                options.UseNpgsql(GlobalConnectionStrings.Clients_MicroDB_Connection));

            services.AddDbContextPool<ClientsDBContext>(options =>
                options.UseNpgsql(GlobalConnectionStrings.Clients_MicroDB_Connection));

            // Repositories
            services.AddScoped<IClientsDbRepository, ClientsDbRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }
    }
}
