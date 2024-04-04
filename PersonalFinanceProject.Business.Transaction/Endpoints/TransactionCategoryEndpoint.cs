using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Business.Transaction.Endpoints
{
    public class TransactionCategoryEndpoint
    {
        private readonly IMessageBus _messageBus;

        public TransactionCategoryEndpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [WolverineGet("api/transaction-category/get/{id}")]
        public async Task<IResult> GetById(TransactionCategoryGetByIdRequestMessage request, CancellationToken cancellationToken)
        {
            TransactionCategoryGetByIdResponseMessage response = await _messageBus.InvokeAsync<TransactionCategoryGetByIdResponseMessage>(request, cancellationToken);
            if (response.TransactionCategory is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/transaction-category/get/list")]
        public async Task<IResult> GetList(TransactionCategoryGetListRequestMessage request, CancellationToken cancellationToken)
        {
            TransactionCategoryGetListResponseMessage response = await _messageBus.InvokeAsync<TransactionCategoryGetListResponseMessage>(request, cancellationToken);

            return Results.Ok(response);
        }
    }
}