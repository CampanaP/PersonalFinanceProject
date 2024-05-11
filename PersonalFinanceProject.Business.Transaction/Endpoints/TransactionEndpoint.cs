using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Communication.Message.Transaction.Responses;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Business.Transaction.Endpoints
{
    public class TransactionEndpoint
    {
        private readonly IMessageBus _messageBus;

        public TransactionEndpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [WolverinePost("api/transaction/add")]
        public async Task<IResult> Add(TransactionAddRequest request, CancellationToken cancellationToken = default)
        {
            TransactionAddResponse response = await _messageBus.InvokeAsync<TransactionAddResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverineDelete("api/transaction/delete/{id}")]
        public async Task<IResult> DeleteById(TransactionDeleteByIdRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }

        [WolverineGet("api/transaction/get/{id}")]
        public async Task<IResult> GetById(string id, CancellationToken cancellationToken = default)
        {
            if (!Guid.TryParse(id, out Guid requestId))
            {
                return Results.BadRequest("Id is not an integer value");
            }

            TransactionGetByIdRequest request = new TransactionGetByIdRequest(requestId);

            TransactionGetByIdResponse response = await _messageBus.InvokeAsync<TransactionGetByIdResponse>(request, cancellationToken);
            if (response.Transaction is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/transaction/get/list")]
        public async Task<IResult> GetList(TransactionGetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionGetListResponse response = await _messageBus.InvokeAsync<TransactionGetListResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverinePut("api/transaction/update/{id}")]
        public async Task<IResult> UpdateById(TransactionUpdateByIdRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }
    }
}