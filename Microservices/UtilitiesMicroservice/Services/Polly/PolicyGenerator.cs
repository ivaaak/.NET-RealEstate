using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Retry;

namespace UtilitiesMicroservice.Services.Polly
{
    public static class PolicyGenerator
    {
        public static AsyncRetryPolicy CreateRetryPolicy(int retryCount, TimeSpan retryInterval, bool useExponentialBackoff = false, bool useRandomJitter = false)
        {
            AsyncRetryPolicy retryPolicy = Policy
                 .Handle<HttpRequestException>()
                 .Or<TimeoutException>()
                 .RetryAsync();


            PolicyBuilder retryPolicyBuilder = Policy
                .Handle<HttpRequestException>()
                .Or<TimeoutException>();

            if (useExponentialBackoff)
            {
                retryPolicy = retryPolicyBuilder.WaitAndRetryAsync(retryCount, attempt => TimeSpan.FromMilliseconds(retryInterval.TotalMilliseconds * Math.Pow(2, attempt)));
            }
            else
            {
                retryPolicy = retryPolicyBuilder.WaitAndRetryAsync(retryCount, attempt => retryInterval);
            }

            /*
            if (useRandomJitter)
            {
                var jitterer = new Random();
                retryPolicy = retryPolicy.WrapAsync(innerPolicy => innerPolicy.WaitAndRetryAsync(retryCount, attempt => retryInterval.Add(TimeSpan.FromMilliseconds(jitterer.Next(0, 100)))));
            }
            */
            return retryPolicy;
        }

        public static AsyncCircuitBreakerPolicy CreateCircuitBreakerPolicy(int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak)
        {
            return Policy
                .Handle<HttpRequestException>()
                .CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak);
        }
        /*
        public static AsyncFallbackPolicy CreateFallbackPolicy(Func<Task<string>> fallbackAction)
        {
            return Policy
                .Handle<HttpRequestException>()
                
                .FallbackAsync(async => {
                    string result = fallbackAction().Result;
                    return result;
                });
        }
        */
        public static AsyncBulkheadPolicy CreateBulkheadPolicy(int maxParallelization, int maxQueuingActions)
        {
            return Policy
                .BulkheadAsync(maxParallelization, maxQueuingActions);
        }
    }
}
