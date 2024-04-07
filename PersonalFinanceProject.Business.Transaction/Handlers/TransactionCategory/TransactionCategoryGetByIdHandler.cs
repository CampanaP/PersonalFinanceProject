using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses;
using PersonalFinanceProject.Infrastructure.EntityMapper.Interfaces.Services;
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

        public async Task<TransactionCategoryGetByIdResponseMessage> Handle(TransactionCategoryGetByIdRequestMessage request, CancellationToken cancellationToken = default)
        {
            TransactionCategoryGetByIdResponseMessage response = new TransactionCategoryGetByIdResponseMessage();

            Entities.TransactionCategory? transactionCategory = await _transactionCategoryService.GetById(request.Id, cancellationToken);
            if (transactionCategory is null)
            {
                return response;
            }

            response.TransactionCategory = _entityMapperService.Map<Entities.TransactionCategory, TransactionCategoryMessageItem>(transactionCategory, true);

            return response;
        }
    }
}