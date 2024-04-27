using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Communication.Message.RevenueSource.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Wallet.Handlers.RevenueSource
{
    [WolverineHandler]
    public class RevenueSourceGetListHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly IRevenueSourceService _revenueSourceService;

        public RevenueSourceGetListHandler(IEntityMapperService entityMapperService, IRevenueSourceService revenueSourceService)
        {
            _entityMapperService = entityMapperService;
            _revenueSourceService = revenueSourceService;
        }

        public async Task<RevenueSourceGetListResponse> Handle(RevenueSourceGetListRequest request, CancellationToken cancellationToken = default)
        {
            RevenueSourceGetListResponse response = new RevenueSourceGetListResponse();

            IEnumerable<Entities.RevenueSource> revenueSources = await _revenueSourceService.GetList(cancellationToken);
            if (revenueSources is null || !revenueSources.Any())
            {
                return response;
            }

            response.RevenueSources = _entityMapperService.MapList<Entities.RevenueSource, RevenueSourceResponseItem>(revenueSources.ToList(), true);

            return response;
        }
    }
}