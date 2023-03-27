using RealEstate.Shared.ServiceExtensions;

namespace UtilitiesMicroservice.Properties
{
    public static class RedisCacheExtension
    {

        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {

            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var redisConnectionString = EnvironmentConfig.Current.RedisConnectionString;

            /*
            services.AddStackExchangeRedisCache(redisOptions =>
            {
                string connection = redisConnectionString;

                redisOptions.Configuration = connection;
            });
            */
            services.AddMemoryCache();

            return services;
        }
    }
}
