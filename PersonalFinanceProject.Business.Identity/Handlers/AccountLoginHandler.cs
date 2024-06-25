using PersonalFinanceProject.Business.Account.Interfaces.Services;

namespace PersonalFinanceProject.Business.Account.Handlers
{
    //[WolverineHandler]
    public class AccountLoginHandler
    {
        private readonly IAccountService identityService;

        public AccountLoginHandler(IAccountService identityService)
        {
            this.identityService = identityService;
        }

        //public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken = default)
        //{
        //    //return await identityService.Login(request, cancellationToken);
        //}
    }
}