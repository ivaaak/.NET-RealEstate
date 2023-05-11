using Hangfire;
using Hangfire.SqlServer;
using RealEstate.Shared;
using RealEstate.Shared.Data.Repository;
using UtilitiesMicroservice.Services.Cache;
using UtilitiesMicroservice.Services.CloudinaryService;
using UtilitiesMicroservice.Services.FileUpload;

namespace UtilitiesMicroservice.Properties
{
    public static class UtilitiesStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services)
        {
            // Services
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IFileUploadService, FileUploadService>();

            // Repositories
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }


        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(redisOptions =>
            {
                string connection = GlobalConnectionStrings.Redis_Connection;

                redisOptions.Configuration = connection;
            });
            services.AddMemoryCache();
            return services;
        }

        public static IServiceCollection AddHangfireWithPostgreSQLServer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            /*
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString(PostgreSQLConnectionString), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                }));
           
            services.AddHangfireServer();
            */
            return services;
        }
        static void HangfireSettings()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Database=Hangfire.Sample; Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true
                });
        }
    }
}
