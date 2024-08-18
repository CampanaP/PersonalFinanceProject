using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Communication.Message.RevenueSource.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Wallet.Handlers.RevenueSource
{
    [WolverineHandler]
    public class RevenueSourceAddHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly IRevenueSourceService _revenueSourceService;

        public RevenueSourceAddHandler(IEntityMapperService entityMapperService, IRevenueSourceService revenueSourceService)
        {
            _entityMapperService = entityMapperService;
            _revenueSourceService = revenueSourceService;
        }

        public async Task<RevenueSourceAddResponse> Handle(RevenueSourceAddRequest request, CancellationToken cancellationToken = default)
        {
            RevenueSourceAddResponse response = new RevenueSourceAddResponse(Guid.Empty);

            Entities.RevenueSource revenueSource = _entityMapperService.Map<RevenueSourceAddRequest, Entities.RevenueSource>(request);

            response.Id = await _revenueSourceService.Add(revenueSource, cancellationToken);

            return response;
        }
    }
}