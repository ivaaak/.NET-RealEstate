namespace RealEstate.ApiGateway.ServiceExtensions
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
