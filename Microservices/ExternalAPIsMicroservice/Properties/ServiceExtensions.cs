using Microsoft.OpenApi.Models;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authentication.Contracts;
using RealEstate.Shared.Data.Repository;

namespace ExternalAPIsMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository), typeof(Repository));
            services.AddScoped(typeof(IApplicationDbRepository), typeof(ApplicationDbRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }

        public static IServiceCollection AddSwaggerWithConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "External APIs Microservice",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            return services;
        }
    }
}
