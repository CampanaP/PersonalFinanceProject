using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Business.Transaction.Messages.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.Responses;
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
        public async Task<IResult> GetById(TransactionCategoryRequestMessage.GetByIdRequest request, CancellationToken cancellationToken)
        {
            TransactionCategoryResponseMessage.GetByIdResponse response = await _messageBus.InvokeAsync<TransactionCategoryResponseMessage.GetByIdResponse>(request, cancellationToken);
            if (response.TransactionCategory is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/transaction-category/get/list")]
        public async Task<IResult> GetList(TransactionCategoryRequestMessage.GetListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TransactionCategoryResponseMessage.GetListResponse response = await _messageBus.InvokeAsync<TransactionCategoryResponseMessage.GetListResponse>(request, cancellationToken);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}