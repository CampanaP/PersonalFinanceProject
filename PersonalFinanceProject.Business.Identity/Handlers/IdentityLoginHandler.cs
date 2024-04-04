using PersonalFinanceProject.Business.Identity.Interfaces.Services;

namespace PersonalFinanceProject.Business.Identity.Handlers
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