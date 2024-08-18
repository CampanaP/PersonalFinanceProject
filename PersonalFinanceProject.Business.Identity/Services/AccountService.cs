using Microsoft.Extensions.Configuration;
using PersonalFinanceProject.Business.Account.Interfaces.Services;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.Identity.Entities;
using PersonalFinanceProject.Library.Identity.Interfaces.Repositories;

namespace PersonalFinanceProject.Business.Account.Services
{
    [ScopedLifetime]
    internal class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityUserRepository _identityUserRepository;

        public AccountService(IConfiguration configuration, IIdentityUserRepository identityUserRepository)
        {
            _configuration = configuration;
            _identityUserRepository = identityUserRepository;
        }

        public async Task<string> Login(string username, string password)
        {


            return string.Empty;
        }

        public async Task Registration(User user, string password, CancellationToken cancellationToken = default)
        {
            bool isSuccess = await _identityUserRepository.Create(user, password);
            if (!isSuccess)
            {
                throw new Exception($"{nameof(AccountService)} - {nameof(Registration)} - Registration is in Error - User Email: {user.Email}");
            }

            await _identityUserRepository.AddToRole(user, "Guest");

            return;
        }
    }
}