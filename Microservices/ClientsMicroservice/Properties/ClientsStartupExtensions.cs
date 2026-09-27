using ClientsMicroservice.Data.Context;
using ClientsMicroservice.Data.Repository;
using ClientsMicroservice.Services;
using ClientsMicroservice.Services.Interfaces;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.ServiceExtensions;

namespace ClientsMicroservice.Properties
{
    public static class ClientsStartupExtensions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClientService, ClientService>();

            // DbContexts using pooling for better performance
            // Keycloak's own database (user_entity, user_attribute, ...) - read via UsersDBContext
            services.AddDbContextPool<UsersDBContext>(options =>
                options.UseNpgsql(GlobalConnectionStrings.Keycloak_DB_Connection));

            // Application schema (CombinedDBContext) + IRepository
            services.AddCombinedDbContext();

            // Repositories
            services.AddScoped<IClientsDbRepository, ClientsDbRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddKeycloakClientConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            // "auth-server-url", "ssl-required", etc. bind to non-public properties in Keycloak.AuthServices 1.x
            var keycloakAdminOptions = configuration
                .GetSection(KeycloakAdminClientOptions.Section)
                .Get<KeycloakAdminClientOptions>(o => o.BindNonPublicProperties = true);

            var keycloakProtectionOptions = configuration
                .GetSection(KeycloakProtectionClientOptions.Section)
                .Get<KeycloakProtectionClientOptions>(o => o.BindNonPublicProperties = true);

            // requires confidential client
            services.AddKeycloakAdminHttpClient(keycloakAdminOptions);

            // based on token forwarding HttpClient middleware and IHttpContextAccessor
            services.AddKeycloakProtectionHttpClient(keycloakProtectionOptions);


            return services;
        }
    }
}
