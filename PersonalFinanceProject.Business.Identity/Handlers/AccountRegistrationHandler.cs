using Microsoft.AspNetCore.Identity;
using PersonalFinanceProject.Business.Account.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Account.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Account.Handlers
{
    [WolverineHandler]
    public class AccountRegistrationHandler
    {
        private readonly IAccountService _accountService;
        private readonly IEntityMapperService _entityMapperService;

        public AccountRegistrationHandler(IAccountService accountService, IEntityMapperService entityMapperService)
        {
            _accountService = accountService;
            _entityMapperService = entityMapperService;
        }

        public async Task Handle(AccountRegistrationRequest request, CancellationToken cancellationToken = default)
        {
            IdentityUser user = _entityMapperService.Map<AccountRegistrationRequest, IdentityUser>(request);

            await _accountService.Registration(user, request.Password, cancellationToken);

            return;
        }
    }
}