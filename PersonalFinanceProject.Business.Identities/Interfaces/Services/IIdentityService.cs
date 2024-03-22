using PersonalFinanceProject.Infrastructure.Communication.Requests.Identity;
using PersonalFinanceProject.Infrastructure.Communication.Responses.Identity;

namespace PersonalFinanceProject.Business.Identities.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken = default);
    }
}