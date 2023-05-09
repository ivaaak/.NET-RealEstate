using ContractsMicroservice.Data.Context;
using ContractsMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared;
using RealEstate.Shared.Data.Repository;

namespace ContractsMicroservice.Properties
{
    public static class ContractsStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IDocumentService, DocumentService>();

            // DbContexts using pooling for better performance
            services.AddDbContextPool<ContractsDBContext>(options => 
                options.UseNpgsql(GlobalConnectionStrings.Contracts_MicroDB_Connection));

            // Repositories
            services.AddTransient<IContractsDbRepository, ContractsDbRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }
    }
}
