using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryUpdateHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryUpdateHandler(IEntityMapperService entityMapperService, ITransactionCategoryService transactionCategoryService)
        {
            _entityMapperService = entityMapperService;
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task Handle(TransactionCategoryUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Entities.TransactionCategory transactionCategory = _entityMapperService.Map<TransactionCategoryUpdateRequest, Entities.TransactionCategory>(request, true);

            await _transactionCategoryService.Update(transactionCategory, cancellationToken);

            return;
        }
    }
}