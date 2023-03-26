using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Shared.CrossCutting.ServiceExtensions
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
