using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Responses;
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
        public async Task<IResult> Add(TransactionCategoryAddRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryAddResponse response = await _messageBus.InvokeAsync<TransactionCategoryAddResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverineDelete("api/transaction-category/delete-by-id")]
        public async Task<IResult> DeleteById(TransactionCategoryDeleteByIdRequest request)
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

            TransactionCategoryGetByIdRequest request = new TransactionCategoryGetByIdRequest(requestId);

            TransactionCategoryGetByIdResponse response = await _messageBus.InvokeAsync<TransactionCategoryGetByIdResponse>(request, cancellationToken);
            if (response.TransactionCategory is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/transaction-category/get/list")]
        public async Task<IResult> GetList(TransactionCategoryGetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetListResponse response = await _messageBus.InvokeAsync<TransactionCategoryGetListResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverinePut("api/transaction-category/update")]
        public async Task<IResult> Update(TransactionCategoryUpdateRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }
    }
}