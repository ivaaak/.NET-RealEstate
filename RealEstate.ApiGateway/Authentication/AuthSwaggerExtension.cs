using Keycloak.AuthServices.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace RealEstate.ApiGateway.Authentication
{
    public static class AuthSwaggerExtension
    {
        public static IServiceCollection AddSwaggerForAuthentication(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, Array.Empty<string>()}
                });
            });
            return services;
        }
        public static IServiceCollection AddSwaggerForAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            KeycloakAuthenticationOptions options = new();

            configuration
                .GetSection(KeycloakAuthenticationOptions.Section)
                .Bind(options, opt => opt.BindNonPublicProperties = true);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Auth",
                    Type = SecuritySchemeType.OAuth2,
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    },
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{options.KeycloakUrlRealm}/protocol/openid-connect/auth"),
                            TokenUrl = new Uri($"{options.KeycloakUrlRealm}/protocol/openid-connect/token"),
                            Scopes = new Dictionary<string, string>(),
                        }
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, Array.Empty<string>()}
                });
            });
            return services;
        }

        public static IApplicationBuilder UseApplicationSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            KeycloakAuthenticationOptions options = new();

            configuration
                .GetSection(KeycloakAuthenticationOptions.Section)
                .Bind(options, opt => opt.BindNonPublicProperties = true);

            app.UseSwagger();
            app.UseSwaggerUI(s => s.OAuthClientId(options.Resource));

            return app;
        }
    }
}
