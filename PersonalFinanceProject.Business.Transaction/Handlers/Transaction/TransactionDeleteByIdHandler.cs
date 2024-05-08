using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.Transaction
{
    [WolverineHandler]
    public class TransactionDeleteByIdHandler
    {
        private readonly ITransactionService _transactionService;

        public TransactionDeleteByIdHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task Handle(TransactionDeleteByIdRequest request, CancellationToken cancellationToken = default)
        {
            await _transactionService.DeleteById(request.Id, cancellationToken);

            return;
        }
    }
}