using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authentication.Contracts;
using RealEstate.ApiGateway.ServiceExtensions;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace UtilitiesMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddSwaggerWithConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Messaging  APIs Microservice",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            return services;
        }
    }
}
