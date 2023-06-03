namespace UtilitiesMicroservice.Services.Polly
{
    public interface IDbQueryPolicy
    {
        /*
        private static readonly Policy _policy = Policy
            .Handle<SqlException>()
            .Or<TimeoutException>()
            .Or<IOException>()
            .WaitAndRetryAsync(
                3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    // Log the retry attempt.
                }
            )
            .CircuitBreakerAsync(
                5,
                TimeSpan.FromSeconds(30),
                (exception, duration) =>
                {
                    // Log the circuit breaker trip.
                },
                () =>
                {
                    // Log the circuit breaker reset.
                }
            );

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
        {
            return await _policy.ExecuteAsync(action);
        }
        */
    }
}
