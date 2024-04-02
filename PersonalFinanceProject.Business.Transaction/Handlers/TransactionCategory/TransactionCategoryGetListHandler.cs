using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.Responses;
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

        public async Task<TransactionCategoryResponseMessage.GetListResponse> Handle(TransactionCategoryRequestMessage.GetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryResponseMessage.GetListResponse response = new TransactionCategoryResponseMessage.GetListResponse(Enumerable.Empty<TransactionCategoryResponseMessage.TransactionCategoryItem>());

            IEnumerable<Entities.TransactionCategory> transactionCategories = await _transactionCategoryService.GetList(cancellationToken);
            if (transactionCategories is null || !transactionCategories.Any())
            {
                return response;
            }

            response = new TransactionCategoryResponseMessage.GetListResponse(transactionCategories.Select(tc => new TransactionCategoryResponseMessage.TransactionCategoryItem(tc.Id, tc.Name)));

            return response;
        }
    }
}