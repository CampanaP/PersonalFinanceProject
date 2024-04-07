using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using PersonalFinanceProject.Infrastructure.EntityMapper.Interfaces.Services;
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

        public async Task<TransactionCategoryAddResponseMessage> Handle(TransactionCategoryAddRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryAddResponseMessage response = new TransactionCategoryAddResponseMessage(default(int));

            Entities.TransactionCategory transactionCategoryItem = _entityMapperService.Map<TransactionCategoryAddRequestMessage, Entities.TransactionCategory>(request, true);

            response.Id = await _transactionCategoryService.Add(transactionCategoryItem, cancellationToken);

            return response;
        }
    }
}