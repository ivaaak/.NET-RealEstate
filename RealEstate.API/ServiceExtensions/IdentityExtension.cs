using Microsoft.AspNetCore.Identity;
using RealEstate.Data.Context;
using RealEstate.Models.Entities.Clients;

namespace RealEstate.API.ServiceExtensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityContext(this IServiceCollection services)
        {
            services.AddDefaultIdentity<Client>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
