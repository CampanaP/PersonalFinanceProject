using PersonalFinanceProject.Business.Identities.Interfaces.Repositories;
using PersonalFinanceProject.Business.Identities.Interfaces.Services;
using PersonalFinanceProject.Infrastructure.Communication.Requests.Identity;
using PersonalFinanceProject.Infrastructure.Communication.Responses.Identity;

namespace PersonalFinanceProject.Business.Identities.Services
{
    internal class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken = default)
        {
            LoginResponse response = new LoginResponse("ERROR", false, null);

            return response;
        }
    }
}