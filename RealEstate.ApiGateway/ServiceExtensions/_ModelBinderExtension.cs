using RealEstate.Core.Constants;
using RealEstate.Infrastructure.ModelBinders;

namespace RealEstate.ApiGateway.ServiceExtensions
{
    public static class _ModelBinderExtension
    {
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
