using Microsoft.AspNetCore.Identity;

namespace PersonalFinanceProject.Business.Account.Interfaces.Services
{
    public interface IAccountService
    {
        //Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken = default);

        Task Registration(IdentityUser user, string password, CancellationToken cancellationToken = default);
    }
}