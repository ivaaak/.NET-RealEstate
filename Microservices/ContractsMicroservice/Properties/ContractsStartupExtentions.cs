using ContractsMicroservice.Services;
using ContractsMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.ServiceExtensions;

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

            // Application schema (CombinedDBContext) + IRepository
            services.AddCombinedDbContext();

            // Repositories
            services.AddScoped<IContractsDbRepository, ContractsDbRepository>();

            return services;
        }
    }
}
