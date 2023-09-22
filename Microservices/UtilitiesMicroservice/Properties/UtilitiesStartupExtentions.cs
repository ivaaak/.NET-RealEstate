using Hangfire;
using Hangfire.SqlServer;
using RealEstate.Shared;
using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Repository;
using UtilitiesMicroservice.Services.CloudinaryService;
using UtilitiesMicroservice.Services.FileUpload;

namespace UtilitiesMicroservice.Properties
{
    public static class UtilitiesStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services)
        {
            // Services
            services.AddSingleton<ICacheService, CacheService>();
            services.AddSingleton<string>("example");

            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddSingleton<CloudinaryDotNet.Cloudinary>();

            // Repositories
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }

        // unused
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(redisOptions =>
            {
                string connection = GlobalConnectionStrings.Redis_Connection;

                redisOptions.Configuration = connection;
            });
            services.AddMemoryCache();
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
