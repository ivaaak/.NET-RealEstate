using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RealEstate.Shared.Data.Repository;

namespace RealEstate.Shared.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IRepository, Repository>();

            return services;
        }

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

        public static IServiceCollection AddRedisCacheWithConnectionString(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration["CacheSettings:ConnectionString"];
            });
            //services.AddHealthChecks().AddRedis(Configuration["CacheSettings:ConnectionString"], "Redis Health", HealthStatus.Degraded);

            return services;
        }

        public static IServiceCollection AddMassTransitWithRabbitMQProvider(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
                    //cfg.UseHealthCheck(context);
                });
            });
            //services.AddMassTransitHostedService();
            //services.AddHealthChecks().AddRedis(builder.Configuration["CacheSettings:ConnectionString"], "Redis Health", HealthStatus.Degraded);
            //services.AddHealthChecks().AddRedis(Configuration["CacheSettings:ConnectionString"], "Redis Health", HealthStatus.Degraded);

            return services;
        }


        // WebApplication Extensions
        public static WebApplication AddSwaggerDevelopmentDocs(this WebApplication app, string MicroserviceName)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{MicroserviceName} Microservice v1"));
            }

            return app;
        }

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
