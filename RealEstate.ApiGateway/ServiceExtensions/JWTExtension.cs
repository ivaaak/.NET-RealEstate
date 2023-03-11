using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authentication.Contracts;
using System.Text;

namespace RealEstate.ApiGateway.ServiceExtensions
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
            });

            return services;
        }

        public static IServiceCollection AddJWTAuthService(this IServiceCollection services)
        {
            services.AddSingleton<IJWTAuthService, JWTAuthService>();

            return services;
        }
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();

            return services;
        }
    }
}