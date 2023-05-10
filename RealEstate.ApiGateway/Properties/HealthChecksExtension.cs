using RealEstate.Shared;

namespace RealEstate.ApiGateway.Properties
{
    public static class HealthChecksExtension
    {
        public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddRabbitMQ(GlobalConnectionStrings.RabbitMQ_Connection, sslOption: null, tags: null, timeout: null)
                .AddRedis(GlobalConnectionStrings.Redis_Connection)
                .AddElasticsearch(GlobalConnectionStrings.Elasticsearch_Connection)
                .AddNpgSql(GlobalConnectionStrings.RealEstate_DB_Connection);
                //.AddNpgSql(GlobalConnectionStrings.Clients_MicroDB_Connection)
                //.AddNpgSql(GlobalConnectionStrings.Contracts_MicroDB_Connection)
                //.AddNpgSql(GlobalConnectionStrings.Estates_MicroDB_Connection)
                //.AddNpgSql(GlobalConnectionStrings.Listings_MicroDB_Connection);

            return services;

            // SQL Server - AspNetCore.HealthChecks.SqlServer
            // AWS S3 -AspNetCore.HealthChecks.Aws.S3
            // SignalR - AspNetCore.HealthChecks.SignalR
        }
    }
}
