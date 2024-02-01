using PersonalFinanceProject.Infrastructure.Notifications.Entities;

namespace PersonalFinanceProject.Infrastructure.Notifications.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmail(EmailMessage message, CancellationToken cancellationToken = default);
    }
}