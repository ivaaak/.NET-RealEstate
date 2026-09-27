#nullable disable
using Keycloak.AuthServices.Authentication;

namespace RealEstate.ApiGateway.Authentication
{
    public static class KeycloakAuthentication
    {
        // Used by the API Gateway and by every microservice (they validate the bearer token Ocelot forwards)
        public static IServiceCollection AddKeycloakAuthenticationConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            // In Keycloak.AuthServices 1.x the adapter-style keys ("auth-server-url", "ssl-required",
            // "verify-token-audience") bind to NON-public properties. Without BindNonPublicProperties they are
            // silently dropped: the authority becomes "/realms/{realm}" and audience validation stays on.
            var authenticationOptions = configuration
                .GetSection(KeycloakAuthenticationOptions.Section)
                .Get<KeycloakAuthenticationOptions>(o => o.BindNonPublicProperties = true)
                ?? throw new InvalidOperationException(
                    $"Missing '{KeycloakAuthenticationOptions.Section}' configuration section.");

            services.AddKeycloakAuthentication(authenticationOptions);

            return services;
        }
    }
}
