using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using PersonalFinanceProject.Infrastructure.Logger.Interfaces.Services;
using PersonalFinanceProject.Infrastructure.Notification.Entities;
using PersonalFinanceProject.Infrastructure.Notification.Enums;
using PersonalFinanceProject.Infrastructure.Notification.Interfaces.Services;
using PersonalFinanceProject.Infrastructure.Notification.Settings;
using Wolverine;

namespace PersonalFinanceProject.Infrastructure.Notification.Services
{
    internal class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerService _loggerService;

        public EmailService(IConfiguration configuration, ILoggerService loggerService)
        {
            _configuration = configuration;
            _loggerService = loggerService;
        }

        private MimeMessage? getMimeMessage(EmailMessage message)
        {
            MimeMessage? mimeMessage = null;

            EmailSetting? setting = _configuration.Get<EmailSetting>();
            if (setting is null || setting.SenderAddress is null)
            {
                return mimeMessage;
            }

            if (setting.SenderDisplayName is null && string.IsNullOrWhiteSpace(message.SenderDisplayName))
            {
                message.SenderDisplayName = setting.SenderAddress.Split("@")?[0] ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(message.SenderAddress))
                {
                    message.SenderDisplayName = message.SenderAddress.Split("@")?[0] ?? string.Empty;
                }
            }

            MailboxAddress sender = new MailboxAddress(setting.SenderDisplayName, setting.SenderAddress);

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
            EmailSetting? settings = _configuration.Get<EmailSetting>();

            if (settings is null || string.IsNullOrWhiteSpace(settings.Host) || string.IsNullOrWhiteSpace(settings.Username) || string.IsNullOrWhiteSpace(settings.Password))
            {
                _loggerService.Error("{emailService} - {sendEmail} - ERROR: Send email - Configurations are not valid", new object[] { nameof(EmailService), nameof(SendEmail) }, null);

                throw new Exception("Send email - Configurations are not valid");
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync(settings.Host, 587, true, cancellationToken);

                    await smtpClient.AuthenticateAsync(settings.Username, settings.Password, cancellationToken);

                    await smtpClient.SendAsync(message, cancellationToken);

                    await smtpClient.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                _loggerService.Error("{emailService} - {sendEmail} - ERROR: Send email - {exceptionMessage}", new object[] { nameof(EmailService), nameof(SendEmail), ex.Message }, ex);

                throw;
            }
        }

        public async Task SendEmail(EmailMessage message, CancellationToken cancellationToken = default)
        {
            MimeMessage? mimeMessage = getMimeMessage(message);
            if (mimeMessage is null)
            {
                _loggerService.Error("{emailService} - {sendEmail} - ERROR: MimeMessage is null", new object[] { nameof(EmailService), nameof(SendEmail) }, null);

                throw new Exception("MimeMessage is null");
            }

            await send(mimeMessage, cancellationToken);
        }
    }
}