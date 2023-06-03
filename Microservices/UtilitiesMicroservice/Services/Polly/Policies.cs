using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;

namespace UtilitiesMicroservice.Services.Polly
{
    public static class Policies
    {
        private static readonly Random jitterer = new Random();

        public static readonly AsyncRetryPolicy RetryPolicy = Policy
            .Handle<HttpRequestException>()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt))
            .Add(TimeSpan.FromMilliseconds(jitterer.Next(0, 100))));


        public static readonly AsyncCircuitBreakerPolicy CircuitBreakerPolicy = Policy
            .Handle<HttpRequestException>()
            .CircuitBreakerAsync(5, TimeSpan.FromMinutes(1));

        public static readonly AsyncFallbackPolicy FallbackPolicy = Policy
            .Handle<HttpRequestException>()
            .FallbackAsync(fallbackAction => { return Task.CompletedTask; });

        public static readonly AsyncBulkheadPolicy BulkheadPolicy = Policy
            .BulkheadAsync(10, 10);

        public static readonly AsyncPolicyWrap AllPolicies = Policy
            .WrapAsync(RetryPolicy, CircuitBreakerPolicy, FallbackPolicy, BulkheadPolicy);

    }

}
