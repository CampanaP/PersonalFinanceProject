using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Communication.Message.TransactionType.Responses;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Business.Transaction.Endpoints
{
    public class TransactionTypeEndpoint
    {
        private readonly IMessageBus _messageBus;

        public TransactionTypeEndpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [WolverinePost("api/transaction-type/add")]
        public async Task<IResult> Add(TransactionTypeAddRequest request, CancellationToken cancellationToken = default)
        {
            TransactionTypeAddResponse response = await _messageBus.InvokeAsync<TransactionTypeAddResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverineDelete("api/transaction-type/delete/{id}")]
        public async Task<IResult> DeleteById(TransactionTypeDeleteByIdRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }

        [WolverineGet("api/transaction-type/get/{id}")]
        public async Task<IResult> GetById(string id, CancellationToken cancellationToken = default)
        {
            if (!int.TryParse(id, out int requestId))
            {
                return Results.BadRequest("Id is not an integer value");
            }

            TransactionTypeGetByIdRequest request = new TransactionTypeGetByIdRequest(requestId);

            TransactionTypeGetByIdResponse response = await _messageBus.InvokeAsync<TransactionTypeGetByIdResponse>(request, cancellationToken);
            if (response.TransactionType is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/transaction-type/get/list")]
        public async Task<IResult> GetList(TransactionTypeGetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionTypeGetListResponse response = await _messageBus.InvokeAsync<TransactionTypeGetListResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverinePut("api/transaction-type/update")]
        public async Task<IResult> Update(TransactionTypeUpdateRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }
    }
}