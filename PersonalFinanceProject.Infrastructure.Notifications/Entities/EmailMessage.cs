using PersonalFinanceProject.Infrastructure.Notification.Enums;

namespace PersonalFinanceProject.Infrastructure.Notification.Entities
{
    public class EmailMessage
    {
        public string? SenderAddress { get; set; }

        public string? SenderDisplayName { get; set; }

        public IEnumerable<string>? Recipients { get; set; }

        public IEnumerable<string>? CarbonCopyRecipients { get; set; }

        public IEnumerable<string>? BlindCarbonCopyRecipients { get; set; }

        public IEnumerable<System.Net.Mail.Attachment>? Attachments { get; set; }

        public required string Subject { get; set; }

        public required string Body { get; set; }

        public EmailBodyFormats BodyFormat { get; set; }
    }
}