using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Shared.ServiceExtensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // Add AutoMapper.
            services.AddAutoMapper();
            //todo settings

            return services;
        }
    }
}
