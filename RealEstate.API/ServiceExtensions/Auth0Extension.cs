using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Configuration;
using System.Security.Claims;

namespace RealEstate.API.ServiceExtensions
{
    public static class Auth0Extension
    {
        public static IServiceCollection AddAuth0Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Auth0";
                options.DefaultChallengeScheme = "Auth0";
            })
            .AddCookie()
            .AddOAuth("Auth0", options =>
            {
                // Set the Auth0 domain, client ID, and client secret.
                /*
                options.ClientId = Configuration["Auth0:ClientId"];
                options.ClientSecret = Configuration["Auth0:ClientSecret"];
                options.CallbackPath = new PathString("/signin-auth0");
                options.AuthorizationEndpoint = $"https://{Configuration["Auth0:Domain"]}/authorize";
                options.TokenEndpoint = $"https://{Configuration["Auth0:Domain"]}/oauth/token";
                options.UserInformationEndpoint = $"https://{Configuration["Auth0:Domain"]}/userinfo";
                */
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "sub");
                options.SaveTokens = true;
                /*
                options.Events = new OAuthEvents
                {
                    // Handle the logout redirect.
                    /*
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // Transform to absolute URI.
                                var request = context.Request;
                                //postLogoutUri.
                            }
                        }
                    }*/
            });
            //.AddSingleton(configuration);

            return services;
        }
    }
}


/*
To add Auth0 authentication to a .NET web application, you can follow these steps:

Sign up for an Auth0 account and create an application in the dashboard.

Install the Auth0.AuthenticationApi NuGet package in your .NET web application.

In your Startup.cs file, configure the authentication services in the ConfigureServices method:

When a user tries to access a controller action or controller class that is decorated with the 
[Authorize] attribute, they will be redirected to the Auth0 login page. After logging in and 
granting the necessary permissions, the user will be redirected back to the application and 
granted access to the protected resources.

You can also use the User property on the Controller base class to access the authenticated 
user's claims and other information. For example:


public class RealEstateController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // Use the user ID to query the database or perform other actions.
    }
}


This example retrieves the authenticated user's ID from the ClaimTypes.NameIdentifier 
claim, which was mapped from the sub field in the user's JSON Web Token (JWT) by the 
ClaimActions.MapJsonKey method in the authentication configuration.

For more information about using Auth0 with ASP.NET, please see the Auth0 documentation:

https://auth0.com/docs/quickstart/webapp/aspnet-core

To add more features to the authentication in your .NET web application, you can use the 
various options and methods provided by the Auth0.AuthenticationApi NuGet package and the 
OAuthOptions class.

For example, you can specify which scopes the user's access token should have by adding 
them to the Scope property of the OAuthOptions class:

    options.Scope.Add("email");
    options.Scope.Add("profile");

You can also specify which claims should be included in the user's JWT by adding them to the 
Claims property of the OAuthOptions class:

    options.Claims = new List<string>
    {
        "email",
        "email_verified",
        "picture"
    };

These claims will be included in the user's JWT and can be accessed via the User property on the 
Controller base class, just like the ClaimTypes.NameIdentifier claim in the previous example.

You can also specify which audience the access token should be issued for by setting the Audience 
property of the OAuthOptions class:

options.Audience = Configuration["Auth0:ApiIdentifier"];

This can be useful if your application is using Auth0's API authorization features, 
such as the /userinfo endpoint or the Management API.

For more information about the various options and methods available for configuring 
authentication in ASP.NET, please see the Auth0 documentation:

https://auth0.com/docs/quickstart/webapp/aspnet-core

https://auth0.com/docs/quickstart/webapp/aspnet-owin/01-login

https://auth0.com/docs/libraries/auth0-aspnet

https://auth0.com/docs/api-auth/tutorials/implicit-grant

https://auth0.com/docs/libraries/auth0-aspnet-owin/v1/mvc-5/get-user-info
*/