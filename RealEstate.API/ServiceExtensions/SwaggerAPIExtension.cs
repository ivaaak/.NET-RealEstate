namespace RealEstate.API.ServiceExtensions
{
    public static class SwaggerAPIExtension
    {
        public static IServiceCollection AddSwaggerAPIWithEndpoints(this IServiceCollection services)
        {
            services
                .AddSwaggerGen()
                .AddEndpointsApiExplorer();

            return services;
        }
    }
}
