using PersonalFinanceProject.Library.Notification.Entities;

namespace PersonalFinanceProject.Library.Notification.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmail(EmailMessage message, CancellationToken cancellationToken = default);
    }
}