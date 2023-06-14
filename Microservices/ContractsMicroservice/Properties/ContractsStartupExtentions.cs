using ContractsMicroservice.Data.Context;
using ContractsMicroservice.Services;
using ContractsMicroservice.Services.Interfaces;
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
            services.AddTransient<IChecklistService, ChecklistService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IProjectService, ProjectService>();

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
