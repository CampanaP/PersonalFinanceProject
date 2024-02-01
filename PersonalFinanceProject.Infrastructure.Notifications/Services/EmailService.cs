using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using PersonalFinanceProject.Infrastructure.Notifications.Entities;
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

        private MimeMessage? getMimeMessage(EmailMessage message)
        {
            MimeMessage? mimeMessage = null;

            MailboxAddress sender = new MailboxAddress(_configuration.GetValue<string>("Smtp:SenderDisplayName"), _configuration.GetValue<string>("Smtp:SenderAddress"));

            if (!string.IsNullOrWhiteSpace(message.SenderAddress))
            {
                sender.Address = message.SenderAddress;
            }

            if (!string.IsNullOrWhiteSpace(message.SenderDisplayName))
            {
                sender.Name = message.SenderDisplayName;
            }

            List<MailboxAddress> recipientMailboxAddresses = new List<MailboxAddress>();
            if (!message.Recipients.IsNullOrEmpty())
            {
                foreach (string recipientEmail in message.Recipients!)
                {
                    recipientMailboxAddresses.Add(new MailboxAddress(recipientEmail.Split("@")?[0] ?? string.Empty, recipientEmail));
                }
            }

            BodyBuilder bodyBuilder = new BodyBuilder()
            {
                HtmlBody = message.BodyFormat == EmailBodyFormats.Html ? message.Body : null,
                TextBody = message.BodyFormat == EmailBodyFormats.Text ? message.Body : null,
            };

            if (!message.Attachments.IsNullOrEmpty())
            {
                foreach (System.Net.Mail.Attachment attachment in message.Attachments!)
                {
                    bodyBuilder.Attachments.Add(new MimePart()
                    {
                        Content = new MimeContent(attachment.ContentStream),
                        FileName = attachment.Name
                    });
                }
            }

            mimeMessage = new MimeMessage(sender, recipientMailboxAddresses, message.Subject, bodyBuilder.ToMessageBody());

            if (!message.CarbonCopyRecipients.IsNullOrEmpty())
            {
                foreach (string carbonCopyRecipient in message.CarbonCopyRecipients!)
                {
                    mimeMessage.Cc.Add(new MailboxAddress(carbonCopyRecipient.Split("@")?[0] ?? string.Empty, carbonCopyRecipient));
                }
            }

            if (!message.BlindCarbonCopyRecipients.IsNullOrEmpty())
            {
                foreach (string blindCarbonCopyRecipient in message.BlindCarbonCopyRecipients!)
                {
                    mimeMessage.Bcc.Add(new MailboxAddress(blindCarbonCopyRecipient.Split("@")?[0] ?? string.Empty, blindCarbonCopyRecipient));
                }
            }

            return mimeMessage;
        }

        private async Task send(MimeMessage message, CancellationToken cancellationToken = default)
        {
            string? host = _configuration.GetValue<string>("Smtp:Host");
            string? username = _configuration.GetValue<string>("Smtp:Username");
            string? password = _configuration.GetValue<string>("Smtp:Password");

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                //TODO LOG
                //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Send email - Configurations are not valid");

                throw new Exception("Send email - Configurations are not valid");
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync(host, 587, true, cancellationToken);

                    await smtpClient.AuthenticateAsync(username, password, cancellationToken);

                    await smtpClient.SendAsync(message, cancellationToken);

                    await smtpClient.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                //TODO LOG
                //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Send email: {JsonSerializer.Serialize(ex)}");

                throw;
            }
        }

        public async Task SendEmail(EmailMessage message, CancellationToken cancellationToken = default)
        {
            MimeMessage? mimeMessage = getMimeMessage(message);
            if (mimeMessage is null)
            {
                //TODO LOG
                //Log.Error($"{nameof(EmailService)} - {nameof(SendEmail)} - ERROR Sender is null");

                throw new Exception("MimeMessage is null");
            }

            await send(mimeMessage, cancellationToken);
        }
    }
}