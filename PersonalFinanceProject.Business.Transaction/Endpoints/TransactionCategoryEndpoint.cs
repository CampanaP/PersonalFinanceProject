using Microsoft.AspNetCore.Http;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Business.Transactions.Endpoints
{
    public class TransactionCategoryEndpoint
    {
        private readonly IMessageBus _messageBus;

        public TransactionCategoryEndpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [WolverineGet("transaction-category/get/:id")]
        public async Task<IResult> GetById(Messages.Requests.TransactionCategoryRequestMessage.GetByIdRequest request, CancellationToken cancellationToken)
        {
            Messages.Responses.TransactionCategoryResponseMessage.GetByIdResponse response = await _messageBus.InvokeAsync<Messages.Responses.TransactionCategoryResponseMessage.GetByIdResponse>(request, cancellationToken);
            if (response.transactionCategory is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("transaction-category/get/list")]
        public async Task<IResult> GetList(Messages.Requests.TransactionCategoryRequestMessage.GetListRequest request, CancellationToken cancellationToken)
        {
            Messages.Responses.TransactionCategoryResponseMessage.GetListResponse response = await _messageBus.InvokeAsync<Messages.Responses.TransactionCategoryResponseMessage.GetListResponse>(request, cancellationToken);

            return Results.Ok(response);
        }
    }
}