using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Communication.Message.TransactionType.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionCategory
{
    [WolverineHandler]
    public class TransactionTypeAddHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeAddHandler(IEntityMapperService entityMapperService, ITransactionTypeService transactionTypeService)
        {
            _entityMapperService = entityMapperService;
            _transactionTypeService = transactionTypeService;
        }

        public async Task<TransactionTypeAddResponse> Handle(TransactionTypeAddRequest request, CancellationToken cancellationToken = default)
        {
            TransactionTypeAddResponse response = new TransactionTypeAddResponse(default(int));

            Entities.TransactionType transactionType = _entityMapperService.Map<TransactionTypeAddRequest, Entities.TransactionType>(request, true);

            response.Id = await _transactionTypeService.Add(transactionType, cancellationToken);

            return response;
        }
    }
}