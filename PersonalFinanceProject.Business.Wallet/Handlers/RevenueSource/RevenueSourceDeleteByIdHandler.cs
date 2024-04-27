using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Wallet.Handlers.RevenueSource
{
    [WolverineHandler]
    public class RevenueSourceDeleteByIdHandler
    {
        private readonly IRevenueSourceService _revenueSourceService;

        public RevenueSourceDeleteByIdHandler(IRevenueSourceService revenueSourceService)
        {
            _revenueSourceService = revenueSourceService;
        }

        public async Task Handle(RevenueSourceDeleteByIdRequest request, CancellationToken cancellationToken = default)
        {
            await _revenueSourceService.DeleteById(request.Id, cancellationToken);

            return;
        }
    }
}