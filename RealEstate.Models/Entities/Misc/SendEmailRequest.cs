namespace RealEstate.Models.Entities.Misc
{
    public class SendEmailRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string HtmlContent { get; set; }
    }
}
