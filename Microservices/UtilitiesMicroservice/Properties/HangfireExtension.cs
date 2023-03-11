using Hangfire;
using Hangfire.SqlServer;

namespace UtilitiesMicroservice.Properties
{
    public static class HangfireExtension
    {
        //PostgreSQL Server connection string
        private static string PostgreSQLConnectionString = @"Host=127.0.0.1;Database=RealEstate;Username=postgres;Password=admin";

        // Microsoft SQL Server connection string (SQL Express Server)
        private static string MySQLConnectionString = @"Server=DESKTOP-6PR2R6Q\SQLEXPRESS01;Database=RealEstate;Trusted_Connection=True";


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
