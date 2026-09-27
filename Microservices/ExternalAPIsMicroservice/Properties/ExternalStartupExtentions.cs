using ExternalAPIsMicroservice.Services;
using ExternalAPIsMicroservice.Services.Interfaces;
using Stripe;

namespace ExternalAPIsMicroservice.Properties
{
    public static class ExternalStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IScraperService, ScraperService>();
            services.AddSingleton<CurrencyConverterService>();

            //
            services.AddTransient<IZillowApiService, ZillowApiService>();
            services.AddTransient<IZillowAgentService, ZillowAgentService>();
            services.AddTransient<IZillowSimilarListingsService, ZillowSimilarListingsService>();

            return services;
        }

        public static IServiceCollection AddStripeInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Stripe configuration
            StripeConfiguration.ApiKey = configuration.GetValue<string>("StripeSettings:SecretKey");

            services.AddScoped<CustomerService>()
                    .AddScoped<ChargeService>()
                    .AddScoped<TokenService>()
                    .AddScoped<StripeClient>()
                    .AddScoped<PaymentIntentService>();

            return services;
        }
    }
}
