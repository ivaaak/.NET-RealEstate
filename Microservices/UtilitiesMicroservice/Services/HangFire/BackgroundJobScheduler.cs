using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace UtilitiesMicroservice.Services.HangFire
{
    public class BackgroundJobScheduler
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public BackgroundJobScheduler(
            IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }


        // SCHEDULE NOTIFICATION
        public void ScheduleNotification(string email, string message, DateTime time)
        {
            // Use the IBackgroundJobClient instance to schedule the SendNotification method.
            _backgroundJobClient.Schedule(() => Console.WriteLine("background task"), time);
        }

        [HttpPost]
        public IActionResult ScheduleJob(string jobName, DateTime scheduledAt)
        {
            _backgroundJobClient.Schedule(() => Console.WriteLine(jobName), scheduledAt);

            return new OkResult();
        }
    }
}