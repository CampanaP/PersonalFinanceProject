using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.Transaction
{
    [WolverineHandler]
    public class TransactionUpdateByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionService _transactionService;

        public TransactionUpdateByIdHandler(IEntityMapperService entityMapperService, ITransactionService transactionService)
        {
            _entityMapperService = entityMapperService;
            _transactionService = transactionService;
        }

        public async Task Handle(TransactionUpdateByIdRequest request, CancellationToken cancellationToken = default)
        {
            Entities.Transaction transaction = _entityMapperService.Map<TransactionUpdateByIdRequest, Entities.Transaction>(request, true);

            await _transactionService.UpdateById(transaction, cancellationToken);

            return;
        }
    }
}