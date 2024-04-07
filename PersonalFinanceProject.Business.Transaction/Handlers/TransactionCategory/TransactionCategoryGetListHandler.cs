using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using PersonalFinanceProject.Infrastructure.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionCategoryGetListHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionCategoryService _transactionCategoryService;

        public TransactionCategoryGetListHandler(IEntityMapperService entityMapperService, ITransactionCategoryService transactionCategoryService)
        {
            _entityMapperService = entityMapperService;
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

            response.TransactionCategories = _entityMapperService.MapList<Entities.TransactionCategory, TransactionCategoryMessageItem>(transactionCategories.ToList(), true);

            return response;
        }
    }
}