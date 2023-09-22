using ListingsMicroservice.Data.Context;
using ListingsMicroservice.Data.Repository;
using ListingsMicroservice.Services;
using ListingsMicroservice.Services._Sorting;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace ListingsMicroservice.Properties
{
    public static class ListingsStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IListingService, ListingService>();
            services.AddTransient<IEstateSortingService, EstateSortingService>();

            // DbContexts using pooling for better performance
            services.AddDbContextPool<ListingsDBContext>(options => 
                options.UseNpgsql(GlobalConnectionStrings.Listings_MicroDB_Connection));
            services.AddDbContextPool<EstatesDBContext>(options =>
                options.UseNpgsql(GlobalConnectionStrings.Estates_MicroDB_Connection));
            // Repositories
            services.AddTransient<IListingsDbRepository, ListingsDbRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }
    }
}
