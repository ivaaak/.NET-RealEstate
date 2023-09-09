using EstatesMicroservice.Services;
using EstatesMicroservice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace EstatesMicroservice.Properties
{
    public static class EstatesStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IEstateService, EstateService>();

            services.AddAutoMapper(typeof(Program));

            // DbContexts using pooling for better performance
            services.AddDbContextPool<EstatesDBContext>(options => 
                options.UseNpgsql(GlobalConnectionStrings.Estates_MicroDB_Connection));

            // Repositories
            services.AddTransient<IEstatesDbRepository, EstatesDbRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }
    }
}
