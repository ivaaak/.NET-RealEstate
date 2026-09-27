using ListingsMicroservice.Data.Repository;
using ListingsMicroservice.Services;
using ListingsMicroservice.Services._Sorting;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.ServiceExtensions;

namespace ListingsMicroservice.Properties
{
    public static class ListingsStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IListingService, ListingService>();
            services.AddTransient<IEstateSortingService, EstateSortingService>();

            // Application schema (CombinedDBContext) + IRepository
            services.AddCombinedDbContext();

            // Repositories
            services.AddScoped<IListingsDbRepository, ListingsDbRepository>();

            return services;
        }
    }
}
