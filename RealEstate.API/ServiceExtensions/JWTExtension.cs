using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RealEstate.API.Authentication;
using System.Text;

namespace RealEstate.API.ServiceExtensions
{
    public static class JWTExtension
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001";
                options.Audience = "https://localhost:5001/resources";
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTAuthService.JWT_SECURITY_KEY))
                };
                /*
                options.Events = new JwtBearerEvents
                {
                    
                    OnRedirectToIdentityProviderForSignOut = context =>
                    {
                        // Set the appropriate parameters on the context object
                        // to customize the behavior of the middleware when
                        // redirecting the user to the identity provider for sign-out.

                        return Task.CompletedTask;
                    }
                    
                };*/
            });

            return services;
        }
    }
}

/*
In this example, we are using the AddJwtBearer method to add the ASP.NET Core JWT bearer authentication 
middleware to the application.Then, we are using the OnRedirectToIdentityProviderForSignOut event on the 
JwtBearerEvents class to handle the OnRedirectToIdentityProviderForSignOut event.

In the event handler, you can add any custom code that you want to run when the middleware redirects 
the user to the identity provider for sign-out. For example, you might want to set the LoginHint or 
PostLogoutRedirectUri properties on the context object to customize the behavior of the middleware.

For more information about the RedirectToIdentityProvider method and other ways to handle the 
OnRedirectToIdentityProviderForSignOut event, you can consult the ASP.NET Core documentation.
*/