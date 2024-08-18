using PersonalFinanceProject.Library.Identity.Entities;

namespace PersonalFinanceProject.Business.Account.Interfaces.Services
{
    public interface IAccountService
    {
        //Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken = default);

        Task Registration(User user, string password, CancellationToken cancellationToken = default);
    }
}