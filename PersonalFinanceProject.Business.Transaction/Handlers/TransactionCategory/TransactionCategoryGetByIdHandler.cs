using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryGetByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryGetByIdHandler(IEntityMapperService entityMapperService, ITransactionCategoryService transactionCategoryService)
        {
            _entityMapperService = entityMapperService;
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<TransactionCategoryGetByIdResponse> Handle(TransactionCategoryGetByIdRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetByIdResponse response = new TransactionCategoryGetByIdResponse();

            Entities.TransactionCategory? transactionCategory = await _transactionCategoryService.GetById(request.Id, cancellationToken);
            if (transactionCategory is null)
            {
                return response;
            }

            response.TransactionCategory = _entityMapperService.Map<Entities.TransactionCategory, TransactionCategoryResponseItem>(transactionCategory, true);

            return response;
        }
    }
}