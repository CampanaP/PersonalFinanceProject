using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Infrastructure.EntityMapper.Interfaces.Services;
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

        public async Task Handle(TransactionCategoryUpdateRequestMessage request, CancellationToken cancellationToken = default)
        {
            Entities.TransactionCategory transactionCategory = _entityMapperService.Map<TransactionCategoryUpdateRequestMessage, Entities.TransactionCategory>(request, true);

            await _transactionCategoryService.Update(transactionCategory, cancellationToken);

            return;
        }
    }
}