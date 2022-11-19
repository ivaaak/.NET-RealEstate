using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Constants;
using RealEstate.Core.Contracts;
using RealEstate.Core.Services;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Data.Repositories;
using RealEstate.Web.ModelBinders;

namespace RealEstate.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        //PostgreSQL Server connection string
        private static string PostgreSQLConnectionString = @"Host=127.0.0.1;Database=RealEstate;Username=postgres;Password=admin";

        // Microsoft SQL Server connection string (SQL Express Server)
        private static string MySQLConnectionString = @"Server=DESKTOP-6PR2R6Q\SQLEXPRESS01;Database=RealEstate;Trusted_Connection=True";

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Context(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(PostgreSQLConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection Use_MicrosoftSQL_Context(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(MySQLConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }


        public static IServiceCollection AddIdentityContext(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
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


        public static IServiceCollection AddModelBinders(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(FormatingConstant.NormalDateFormat));
                    options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
                });

            return services;
        }
    }
}
