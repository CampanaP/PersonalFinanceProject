using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryGetListHandler
    {
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryGetListHandler(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<TransactionCategoryGetListResponseMessage> Handle(TransactionCategoryGetListRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetListResponseMessage response = new TransactionCategoryGetListResponseMessage();

            IEnumerable<Entities.TransactionCategory> transactionCategories = await _transactionCategoryService.GetList(cancellationToken);
            if (transactionCategories is null || !transactionCategories.Any())
            {
                return response;
            }

            response.TransactionCategories = transactionCategories.Select(tc => new TransactionCategoryMessageItem(tc.Id, tc.Name));

            return response;
        }
    }
}