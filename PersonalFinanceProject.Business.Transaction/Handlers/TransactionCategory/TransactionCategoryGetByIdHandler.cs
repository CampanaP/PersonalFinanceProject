using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.Responses;
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

        public async Task<TransactionCategoryResponseMessage.GetByIdResponse> Handle(TransactionCategoryRequestMessage.GetByIdRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryResponseMessage.GetByIdResponse response = new TransactionCategoryResponseMessage.GetByIdResponse(null);

            Entities.TransactionCategory? transactionCategory = await _transactionCategoryService.GetById(request.id, cancellationToken);
            if (transactionCategory is null)
            {
                return response;
            }

            response = new TransactionCategoryResponseMessage.GetByIdResponse(new TransactionCategoryResponseMessage.TransactionCategoryItem(transactionCategory.Id, transactionCategory.Name));

            return response;
        }
    }
}