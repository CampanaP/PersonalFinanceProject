using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Wallet.Handlers.RevenueSource
{
    [WolverineHandler]
    public class RevenueSourceUpdateByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly IRevenueSourceService _revenueSourceService;

        public RevenueSourceUpdateByIdHandler(IEntityMapperService entityMapperService, IRevenueSourceService revenueSourceService)
        {
            _entityMapperService = entityMapperService;
            _revenueSourceService = revenueSourceService;
        }

        public async Task Handle(RevenueSourceUpdateByIdRequest request, CancellationToken cancellationToken = default)
        {
            Entities.RevenueSource revenueSource = _entityMapperService.Map<RevenueSourceUpdateByIdRequest, Entities.RevenueSource>(request, true);

            await _revenueSourceService.UpdateById(revenueSource, cancellationToken);

            return;
        }
    }
}