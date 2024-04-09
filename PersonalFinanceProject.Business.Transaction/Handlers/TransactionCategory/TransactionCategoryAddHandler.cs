using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryAddHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryAddHandler(IEntityMapperService entityMapperService, ITransactionCategoryService transactionCategoryService)
        {
            _entityMapperService = entityMapperService;
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<TransactionCategoryAddResponse> Handle(TransactionCategoryAddRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryAddResponse response = new TransactionCategoryAddResponse(default(int));

            Entities.TransactionCategory transactionCategoryItem = _entityMapperService.Map<TransactionCategoryAddRequest, Entities.TransactionCategory>(request, true);

            response.Id = await _transactionCategoryService.Add(transactionCategoryItem, cancellationToken);

            return response;
        }
    }
}