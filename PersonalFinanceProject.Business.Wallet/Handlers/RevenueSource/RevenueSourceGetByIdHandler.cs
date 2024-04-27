using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Communication.Message.RevenueSource.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Wallet.Handlers.RevenueSource
{
    [WolverineHandler]
    public class RevenueSourceGetByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly IRevenueSourceService _revenueSourceService;

        public RevenueSourceGetByIdHandler(IEntityMapperService entityMapperService, IRevenueSourceService revenueSourceService)
        {
            _entityMapperService = entityMapperService;
            _revenueSourceService = revenueSourceService;
        }

        public async Task<RevenueSourceGetByIdResponse> Handle(RevenueSourceGetByIdRequest request, CancellationToken cancellationToken = default)
        {
            RevenueSourceGetByIdResponse response = new RevenueSourceGetByIdResponse();

            Entities.RevenueSource? revenueSource = await _revenueSourceService.GetById(request.Id, cancellationToken);
            if (revenueSource is null)
            {
                return response;
            }

            response = _entityMapperService.Map<Entities.RevenueSource, RevenueSourceGetByIdResponse>(revenueSource, true);

            return response;
        }
    }
}