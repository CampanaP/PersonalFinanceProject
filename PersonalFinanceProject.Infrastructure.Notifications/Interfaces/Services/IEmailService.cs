using PersonalFinanceProject.Infrastructure.Notification.Entities;

namespace PersonalFinanceProject.Infrastructure.Notification.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmail(EmailMessage message, CancellationToken cancellationToken = default);
    }
}