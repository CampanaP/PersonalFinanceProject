using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Wallet.Handlers.RevenueSource
{
    [WolverineHandler]
    public class RevenueSourceUpdateHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly IRevenueSourceService _revenueSourceService;

        public RevenueSourceUpdateHandler(IEntityMapperService entityMapperService, IRevenueSourceService revenueSourceService)
        {
            _entityMapperService = entityMapperService;
            _revenueSourceService = revenueSourceService;
        }

        public async Task Handle(RevenueSourceUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Entities.RevenueSource revenueSource = _entityMapperService.Map<RevenueSourceUpdateRequest, Entities.RevenueSource>(request, true);

            await _revenueSourceService.Update(revenueSource, cancellationToken);

            return;
        }
    }
}