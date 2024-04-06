using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryUpdateHandler
    {
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryUpdateHandler(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task Handle(TransactionCategoryUpdateRequestMessage request, CancellationToken cancellationToken = default)
        {
            Entities.TransactionCategory transactionCategory = new Entities.TransactionCategory(request.Id, request.Name);

            await _transactionCategoryService.Update(transactionCategory, cancellationToken);

            return;
        }
    }
}