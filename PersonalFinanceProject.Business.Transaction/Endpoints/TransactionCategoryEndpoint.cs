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

        [WolverinePost("api/transaction-category/add")]
        public async Task<IResult> Add(TransactionCategoryAddRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryAddResponseMessage response = await _messageBus.InvokeAsync<TransactionCategoryAddResponseMessage>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverineDelete("api/transaction-category/delete-by-id")]
        public async Task<IResult> DeleteById(TransactionCategoryDeleteByIdRequestMessage request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }

        [WolverineGet("api/transaction-category/get/{id}")]
        public async Task<IResult> GetById(string id, CancellationToken cancellationToken = default)
        {
            if (!int.TryParse(id, out int requestId))
            {
                return Results.BadRequest("Id is not an integer value");
            }

            TransactionCategoryGetByIdRequestMessage request = new TransactionCategoryGetByIdRequestMessage(requestId);

            TransactionCategoryGetByIdResponseMessage response = await _messageBus.InvokeAsync<TransactionCategoryGetByIdResponseMessage>(request, cancellationToken);
            if (response.TransactionCategory is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/transaction-category/get/list")]
        public async Task<IResult> GetList(TransactionCategoryGetListRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetListResponseMessage response = await _messageBus.InvokeAsync<TransactionCategoryGetListResponseMessage>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverinePut("api/transaction-category/update")]
        public async Task<IResult> Update(TransactionCategoryUpdateRequestMessage request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }
    }
}