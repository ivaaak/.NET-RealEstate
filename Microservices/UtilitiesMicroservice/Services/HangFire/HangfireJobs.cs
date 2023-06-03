using Hangfire;

namespace UtilitiesMicroservice.Services.HangFire
{
    public static class HangfireJobs
    {
        public static void BackgroundJobsCollection()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }
        }

        public static void FireAndForgetJob(string JobText)
        {
            var jobId = BackgroundJob.Enqueue(
                () => Console.WriteLine($"Fire-and-forget! - {JobText}"));
        }

        public static void DelayedJob(string JobText)
        {
            var jobId = BackgroundJob.Schedule(
                () => Console.WriteLine($"Delayed! - {JobText}"),
                TimeSpan.FromDays(7));
        }

        public static void ContinuousJob()
        {
            var jobId = BackgroundJob.Schedule(
                () => Console.WriteLine("Delayed!"),
                TimeSpan.FromDays(1));

            BackgroundJob.ContinueJobWith(
                jobId,
                () => Console.WriteLine("Continuation!"));
        }

        public static void RecurringJobMethod()
        {
            RecurringJob.AddOrUpdate(
                "myrecurringjob",
                () => Console.WriteLine("Recurring!"),
                Cron.Daily);
        }
    }
}
