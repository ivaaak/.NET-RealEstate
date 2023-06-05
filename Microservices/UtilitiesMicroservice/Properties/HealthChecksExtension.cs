using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using RealEstate.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UtilitiesMicroservice.Properties
{
    public static class HealthChecksExtension
    {
        public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddRabbitMQ(GlobalConnectionStrings.RabbitMQ_Connection, sslOption: null, tags: null, timeout: null)
                .AddRedis(GlobalConnectionStrings.Redis_Connection)
                .AddElasticsearch(GlobalConnectionStrings.Elasticsearch_Connection)
                .AddNpgSql(GlobalConnectionStrings.Estates_MicroDB_Connection);
            //.AddNpgSql(GlobalConnectionStrings.Clients_MicroDB_Connection)
            //.AddNpgSql(GlobalConnectionStrings.Contracts_MicroDB_Connection)
            //.AddNpgSql(GlobalConnectionStrings.Estates_MicroDB_Connection)
            //.AddNpgSql(GlobalConnectionStrings.Listings_MicroDB_Connection);

            return services;

            // SQL Server - AspNetCore.HealthChecks.SqlServer
            // AWS S3 -AspNetCore.HealthChecks.Aws.S3
            // SignalR - AspNetCore.HealthChecks.SignalR
        }

        public static WebApplication MapAndUseMultipleHealthChecks(this WebApplication app, string endpoint)
        {
            app.MapHealthChecks(
                endpoint,
                new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }
            );

            return app;
        }

        public static IServiceCollection AddSwaggerWithSchemaOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v100", new OpenApiInfo { Title = "HealthChecks", Version = "v100" });

                // Customize the Swagger schema
                c.SchemaFilter<ExcludeNestedModels>();
            });
        }

        // Define a custom schema filter to exclude types from the Stripe.NET library
        public class ExcludeNestedModels : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                schema.Example = null;
                schema.Properties.Clear();
            }
        }
    }
}
