using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using PersonalFinanceProject.Infrastructure.Notifications.Enums;
using PersonalFinanceProject.Infrastructure.Notifications.Interfaces.Services;

namespace PersonalFinanceProject.Infrastructure.Notifications.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void SendEmail(MimeMessage email)
        {
            string? host = _configuration.GetValue<string>("Smtp:Host");
            string? username = _configuration.GetValue<string>("Smtp:Username");
            string? password = _configuration.GetValue<string>("Smtp:Password");

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                //TODO LOG
                //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Send email - Configurations are not valid");

                return;
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(host, 587, false);

                    smtpClient.Authenticate(username, password);

                    smtpClient.Send(email);

                    smtpClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                //TODO LOG
                //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Send email: {JsonSerializer.Serialize(ex)}");
            }
        }

        public void SendEmail(IEnumerable<string> recipients, string subject, string body, EmailBodyFormats bodyFormat, string? sender = null, string? displayName = null, IEnumerable<string>? carbonCopyRecipients = null, IEnumerable<System.Net.Mail.Attachment>? attachments = null)
        {
            if (string.IsNullOrWhiteSpace(sender))
            {
                sender = _configuration.GetValue<string>("Smtp:FromAddress");

                if (string.IsNullOrWhiteSpace(sender))
                {
                    //TODO LOG
                    //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Sender is null");

                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(displayName))
            {
                displayName = _configuration.GetValue<string>("Smtp:DisplayName");
            }

            try
            {
                List<MailboxAddress> recipientMailboxAddresses = new List<MailboxAddress>();
                foreach (string recipientEmail in recipients)
                {
                    recipientMailboxAddresses.Add(new MailboxAddress(recipientEmail.Split("@")?[0] ?? string.Empty, recipientEmail));
                }

                List<MailboxAddress> fromMailboxAddresses = new List<MailboxAddress>() { new MailboxAddress(displayName, sender) };

                BodyBuilder bodyBuilder = new BodyBuilder()
                {
                    HtmlBody = bodyFormat == EmailBodyFormats.Html ? body : null,
                    TextBody = bodyFormat == EmailBodyFormats.Text ? body : null,
                };

                if (!attachments.IsNullOrEmpty())
                {
                    foreach (System.Net.Mail.Attachment attachment in attachments!)
                    {
                        bodyBuilder.Attachments.Add(new MimePart()
                        {
                            Content = new MimeContent(attachment.ContentStream),
                            FileName = attachment.Name
                        });
                    }
                }

                MimeMessage message = new MimeMessage(fromMailboxAddresses, recipientMailboxAddresses, subject, bodyBuilder.ToMessageBody());

                if (!carbonCopyRecipients.IsNullOrEmpty())
                {
                    foreach (string carbonCopyRecipient in carbonCopyRecipients!)
                    {
                        message.Cc.Add(new MailboxAddress(carbonCopyRecipient.Split("@")?[0] ?? string.Empty, carbonCopyRecipient));
                    }
                }

                Task.Run(() => SendEmail(message)).ContinueWith(completedTaks =>
                {
                    if (completedTaks.IsFaulted && completedTaks.Exception is not null && completedTaks.Exception.InnerException is not null)
                    {
                        //TODO LOG
                        //Log.Error($"{nameof(SendEmail)} - ExceptionMessage: {completedTaks.Exception.InnerException.Message} - ExceptionStackTrace: {completedTaks.Exception.InnerException.StackTrace}");
                    }
                });
            }
            catch (Exception ex)
            {
                //TODO LOG
                //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Send email: {JsonSerializer.Serialize(ex)}");
            }

            return;
        }
    }
}