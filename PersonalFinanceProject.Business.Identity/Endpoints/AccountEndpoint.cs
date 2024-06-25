using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Communication.Message.Account.Requests;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Business.Account.Endpoints
{
    public class AccountEndpoint
    {
        private readonly IMessageBus _messageBus;

        public AccountEndpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [WolverinePost("api/account/registration")]
        public async Task<IResult> Registration(AccountRegistrationRequest request, CancellationToken cancellationToken)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }
    }
}