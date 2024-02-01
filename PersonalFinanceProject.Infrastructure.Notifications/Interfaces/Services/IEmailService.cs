using PersonalFinanceProject.Infrastructure.Notifications.Enums;
using System.Net.Mail;

namespace PersonalFinanceProject.Infrastructure.Notifications.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(IEnumerable<string> recipients, string subject, string body, EmailBodyFormats bodyFormat, string? sender = null, string? displayName = null, IEnumerable<string>? carbonCopyRecipients = null, IEnumerable<Attachment>? attachments = null);
    }
}