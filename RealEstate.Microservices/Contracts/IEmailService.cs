namespace RealEstate.Microservices.Contracts
{
    public interface IEmailService
    {
        // SEND EMAIL
        Task SendEmailAsync(string from, string to, string subject, string htmlContent);

        // SEND EMAIL WITH ATTACHMENT
        Task SendEmailWithAttachmentAsync(string from,string to,string subject,string htmlContent,string fileName,Stream fileStream);
    }
}
