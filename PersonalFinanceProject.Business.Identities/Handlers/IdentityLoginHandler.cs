using PersonalFinanceProject.Business.Identities.Interfaces.Services;
using PersonalFinanceProject.Infrastructure.Communication.Requests.Identity;
using PersonalFinanceProject.Infrastructure.Communication.Responses.Identity;

namespace PersonalFinanceProject.Business.Identities.Handlers
{
    //[WolverineHandler]
    public class IdentityLoginHandler
    {
        private readonly IIdentityService identityService;

        public IdentityLoginHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        //public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken = default)
        //{
        //    //return await identityService.Login(request, cancellationToken);
        //}
    }
}