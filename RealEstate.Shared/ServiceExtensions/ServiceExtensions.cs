using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RealEstate.Shared.Data.Cache;

namespace RealEstate.Shared.ServiceExtensions
{
    public static class ServiceExtensions
    {
        // Swagger
        public static IServiceCollection AddSwaggerWithConfig(this IServiceCollection services, string MicroserviceName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{MicroserviceName} Microservice",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            return services;
        }
        // WebApplication Extensions
        public static WebApplication UseSwaggerDevelopmentDocs(this WebApplication app, string MicroserviceName)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{MicroserviceName} Microservice v1"));

            return app;
        }

        // Redis
        public static IServiceCollection AddRedisCacheWithConnectionString(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = GlobalConnectionStrings.Redis_Connection;
            });

            services.AddTransient<ICacheService, CacheService>();

            return services;
        }


        // HealthChecks
        public static WebApplication MapHealthCheckEndpoint(this WebApplication app)
        {
            app.Map("/hc", builder =>
            {
                builder.UseHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            return app;
        }
    }
}
