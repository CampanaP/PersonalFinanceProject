using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryDeleteByIdHandler
    {
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryDeleteByIdHandler(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task Handle(TransactionCategoryDeleteByIdRequest request, CancellationToken cancellationToken = default)
        {
            await _transactionCategoryService.DeleteById(request.Id, cancellationToken);

            return;
        }
    }
}