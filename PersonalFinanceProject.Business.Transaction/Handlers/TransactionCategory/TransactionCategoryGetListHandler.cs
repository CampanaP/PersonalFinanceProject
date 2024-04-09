using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
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

        public async Task<TransactionCategoryGetListResponse> Handle(TransactionCategoryGetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetListResponse response = new TransactionCategoryGetListResponse();

            IEnumerable<Entities.TransactionCategory> transactionCategories = await _transactionCategoryService.GetList(cancellationToken);
            if (transactionCategories is null || !transactionCategories.Any())
            {
                return response;
            }

            response.TransactionCategories = _entityMapperService.MapList<Entities.TransactionCategory, TransactionCategoryResponseItem>(transactionCategories.ToList(), true);

            return response;
        }
    }
}