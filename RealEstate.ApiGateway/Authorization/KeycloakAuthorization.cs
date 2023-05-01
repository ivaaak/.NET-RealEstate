using Keycloak.AuthServices.Authorization;
using RealEstate.ApiGateway.Authorization.AuthorizationConstants;

namespace RealEstate.ApiGateway.Authorization
{
    public static partial class KeycloakAuthorization
    {
        public static IServiceCollection AddKeycloakAuthorizationConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    Policies.RequireAspNetCoreRole,
                    builder => builder.RequireRole(Roles.AspNetCoreRole));

                options.AddPolicy(
                    Policies.RequireRealmRole,
                    builder => builder.RequireRealmRoles(Roles.RealmRole));

                options.AddPolicy(
                    Policies.RequireClientRole,
                    builder => builder.RequireResourceRoles(Roles.ClientRole));

                options.AddPolicy(
                    Policies.RequireToBeInKeycloakGroupAsReader,
                    builder => builder
                        .RequireAuthenticatedUser()
                        .RequireProtectedResource("workspace", "workspaces:read"));

            }).AddKeycloakAuthorization(configuration);

            return services;
        }
    }
}
