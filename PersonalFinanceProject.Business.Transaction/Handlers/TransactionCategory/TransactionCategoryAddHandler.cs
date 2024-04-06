using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryAddHandler
    {
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryAddHandler(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<TransactionCategoryAddResponseMessage> Handle(TransactionCategoryAddRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryAddResponseMessage response = new TransactionCategoryAddResponseMessage(default(int));

            response.Id = await _transactionCategoryService.Add(new Entities.TransactionCategory(default(int), request.Name), cancellationToken);

            return response;
        }
    }
}