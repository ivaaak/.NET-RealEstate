using Hangfire;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;

namespace MessagingMicroservice.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly SendGridClient _client;
        private readonly string apiKey = "api-key-goes-here";
        private readonly IBackgroundJobClient _backgroundJobClient;

        public EmailService(IBackgroundJobClient backgroundJobClient)
        {
            _client = new SendGridClient(this.apiKey);
            _backgroundJobClient = backgroundJobClient;
        }

        // SEND EMAIL
        public async Task SendEmailAsync(
            string from,
            string to,
            string subject,
            string htmlContent)
        {
            var msg = new SendGridMessage
            {
                From = new EmailAddress(from),
                Subject = subject,
                PlainTextContent = htmlContent,
                HtmlContent = htmlContent
            };
            msg.AddTo(new EmailAddress(to));

            await _client.SendEmailAsync(msg);
        }

        // SEND EMAIL WITH ATTACHMENT
        public async Task SendEmailWithAttachmentAsync(
            string from,
            string to,
            string subject,
            string htmlContent,
            string fileName,
            Stream fileStream)
        {
            var msg = new SendGridMessage
            {
                From = new EmailAddress(from),
                Subject = subject,
                PlainTextContent = htmlContent,
                HtmlContent = htmlContent
            };
            msg.AddTo(new EmailAddress(to));

            var attachment = new Attachment
            {
                Content = Convert.ToBase64String(ReadFully(fileStream)),
                Filename = fileName,
                Type = "application/octet-stream"
            };
            msg.AddAttachment(attachment);

            await _client.SendEmailAsync(msg);
        }

        // SEND EMAIL WITH CUSTOM HEADERS
        public async Task SendEmailWithCustomHeadersAsync(
            string from,
            string to,
            string subject,
            string htmlContent,
            Dictionary<string, string> headers)
        {
            var msg = new SendGridMessage
            {
                From = new EmailAddress(from),
                Subject = subject,
                PlainTextContent = htmlContent,
                HtmlContent = htmlContent
            };
            msg.AddTo(new EmailAddress(to));

            foreach (var header in headers)
            {
                msg.AddHeader(header.Key, header.Value);
            }

            await _client.SendEmailAsync(msg);
        }

        public void ScheduleNotification(SendGridMessage email, DateTime time)
        {
            // Use the IBackgroundJobClient instance to schedule the SendNotification method.
            _backgroundJobClient.Schedule(() => SendEmailAsync(email.From.Name, email.ReplyTo.Email, email.Subject, email.HtmlContent), time);
        }


        private static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
