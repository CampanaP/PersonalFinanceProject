using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionType
{
    [WolverineHandler]
    public class TransactionTypeDeleteByIdHandler
    {
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeDeleteByIdHandler(ITransactionTypeService transactionTypeService)
        {
            _transactionTypeService = transactionTypeService;
        }

        public async Task Handle(TransactionTypeDeleteByIdRequest request, CancellationToken cancellationToken = default)
        {
            await _transactionTypeService.DeleteById(request.Id, cancellationToken);

            return;
        }
    }
}