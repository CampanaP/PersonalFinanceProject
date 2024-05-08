using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionType
{
    [WolverineHandler]
    public class TransactionTypeUpdateHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeUpdateHandler(IEntityMapperService entityMapperService, ITransactionTypeService transactionTypeService)
        {
            _entityMapperService = entityMapperService;
            _transactionTypeService = transactionTypeService;
        }

        public async Task Handle(TransactionTypeUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Entities.TransactionType transactionType = _entityMapperService.Map<TransactionTypeUpdateRequest, Entities.TransactionType>(request, true);

            await _transactionTypeService.Update(transactionType, cancellationToken);

            return;
        }
    }
}