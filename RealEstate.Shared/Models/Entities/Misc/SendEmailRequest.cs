#nullable disable
namespace RealEstate.Shared.Models.Entities.Misc
{
    public class SendEmailRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string HtmlContent { get; set; }

        public Stream FileStream { get; set; }

        public string FileName { get; set; }

        public Dictionary<string, string> Header { get; set; }
    }
}
