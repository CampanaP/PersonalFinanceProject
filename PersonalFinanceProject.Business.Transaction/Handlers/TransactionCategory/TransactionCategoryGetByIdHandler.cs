using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryGetByIdHandler
    {
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryGetByIdHandler(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<TransactionCategoryGetByIdResponseMessage> Handle(TransactionCategoryGetByIdRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetByIdResponseMessage response = new TransactionCategoryGetByIdResponseMessage();

            Entities.TransactionCategory? transactionCategory = await _transactionCategoryService.GetById(request.Id, cancellationToken);
            if (transactionCategory is null)
            {
                return response;
            }

            response.TransactionCategory = new TransactionCategoryMessageItem(transactionCategory.Id, transactionCategory.Name);

            return response;
        }
    }
}