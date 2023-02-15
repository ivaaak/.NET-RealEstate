namespace MessagingMicroservice.Services.Email
{
    public interface IEmailService
    {
        // SEND EMAIL
        Task SendEmailAsync(string from, string to, string subject, string htmlContent);

        // SEND EMAIL WITH ATTACHMENT
        Task SendEmailWithAttachmentAsync(string from, string to, string subject, string htmlContent, string fileName, Stream fileStream);

        // SEND EMAIL WITH CUSTOM HEADER
        Task SendEmailWithCustomHeadersAsync(string from, string to, string subject, string htmlContent, Dictionary<string, string> headers);
    }
}
