using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionType
{
    [WolverineHandler]
    public class TransactionUpdateHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionService _transactionService;

        public TransactionUpdateHandler(IEntityMapperService entityMapperService, ITransactionService transactionService)
        {
            _entityMapperService = entityMapperService;
            _transactionService = transactionService;
        }

        public async Task Handle(TransactionUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Entities.Transaction transaction = _entityMapperService.Map<TransactionUpdateRequest, Entities.Transaction>(request, true);

            await _transactionService.Update(transaction, cancellationToken);

            return;
        }
    }
}