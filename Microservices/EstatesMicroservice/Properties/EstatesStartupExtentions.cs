using EstatesMicroservice.Services;
using EstatesMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.ServiceExtensions;

namespace EstatesMicroservice.Properties
{
    public static class EstatesStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IEstateService, EstateService>();

            services.AddAutoMapper(typeof(Program));

            // Application schema (CombinedDBContext) + IRepository
            services.AddCombinedDbContext();

            // Repositories
            services.AddScoped<IEstatesDbRepository, EstatesDbRepository>();
            services.AddScoped<IClientsDbRepository, ClientsDbRepository>(); // used by FavoritesService

            return services;
        }
    }
}
