using PersonalFinanceProject.Business.Identity.Interfaces.Repositories;
using PersonalFinanceProject.Business.Identity.Interfaces.Services;

namespace PersonalFinanceProject.Business.Identity.Services
{
    internal class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        //public async Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken = default)
        //{
        //    LoginResponse response = new LoginResponse("ERROR", false, null);

        //    return response;
        //}
    }
}