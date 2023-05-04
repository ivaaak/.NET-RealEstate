using Stripe;

namespace ExternalAPIsMicroservice.Services
{
    public static class StripeExtension
    {
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