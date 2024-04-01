using PersonalFinanceProject.Business.Transactions.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transactions.Handlers.TransactionCategory
{
    [WolverineHandler]
    internal class TransactionCategoryGetByIdHandler
    {
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryGetByIdHandler(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<Messages.Responses.TransactionCategoryResponseMessage.GetByIdResponse> Handle(Messages.Requests.TransactionCategoryRequestMessage.GetByIdRequest request, CancellationToken cancellationToken = default)
        {
            Messages.Responses.TransactionCategoryResponseMessage.GetByIdResponse response = new Messages.Responses.TransactionCategoryResponseMessage.GetByIdResponse(null);

            Entities.TransactionCategory? transactionCategory = await _transactionCategoryService.GetById(request.id, cancellationToken);
            if (transactionCategory is null)
            {
                return response;
            }

            response = new Messages.Responses.TransactionCategoryResponseMessage.GetByIdResponse(new Messages.Responses.TransactionCategoryResponseMessage.TransactionCategoryItem(transactionCategory.Id, transactionCategory.Name));

            return response;
        }
    }
}