#nullable disable
using Keycloak.AuthServices.Authentication;

namespace RealEstate.ApiGateway.Authentication
{
    public static class KeycloakAuthentication
    {
        public static IServiceCollection AddKeycloakAuthenticationConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationOptions = configuration
                .GetSection(KeycloakAuthenticationOptions.Section)
                .Get<KeycloakAuthenticationOptions>();

            services.AddKeycloakAuthentication(authenticationOptions);

            return services;
        }
    }
}
