using PersonalFinanceProject.Business.Account.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Account.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using PersonalFinanceProject.Library.Identity.Entities;
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
            User user = _entityMapperService.Map<AccountRegistrationRequest, User>(request);

            user = _entityMapperService.Set<User>(u => u.UserName == u.Email);

            await _accountService.Registration(user, request.Password, cancellationToken);

            return;
        }
    }
}