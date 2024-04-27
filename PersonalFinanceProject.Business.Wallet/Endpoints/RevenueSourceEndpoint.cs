using Microsoft.AspNetCore.Http;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Communication.Message.RevenueSource.Responses;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Business.Wallet.Endpoints
{
    public class RevenueSourceEndpoint
    {
        private readonly IMessageBus _messageBus;

        public RevenueSourceEndpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [WolverinePost("api/revenue-source/add")]
        public async Task<IResult> Add(RevenueSourceAddRequest request, CancellationToken cancellationToken = default)
        {
            RevenueSourceAddResponse response = await _messageBus.InvokeAsync<RevenueSourceAddResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverineDelete("api/revenue-source/delete/{id}")]
        public async Task<IResult> DeleteById(RevenueSourceDeleteByIdRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }

        [WolverineGet("api/revenue-source/get/{id}")]
        public async Task<IResult> GetById(string id, CancellationToken cancellationToken = default)
        {
            if (!Guid.TryParse(id, out Guid requestId))
            {
                return Results.BadRequest("Id is not an integer value");
            }

            RevenueSourceGetByIdRequest request = new RevenueSourceGetByIdRequest(requestId);

            RevenueSourceGetByIdResponse response = await _messageBus.InvokeAsync<RevenueSourceGetByIdResponse>(request, cancellationToken);
            if (response.RevenueSource is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(response);
        }

        [WolverineGet("api/revenue-source/get/list")]
        public async Task<IResult> GetList(RevenueSourceGetListRequest request, CancellationToken cancellationToken = default)
        {
            RevenueSourceGetListResponse response = await _messageBus.InvokeAsync<RevenueSourceGetListResponse>(request, cancellationToken);

            return Results.Ok(response);
        }

        [WolverinePut("api/revenue-source/update")]
        public async Task<IResult> Update(RevenueSourceUpdateRequest request)
        {
            await _messageBus.SendAsync(request);

            return Results.Ok();
        }
    }
}