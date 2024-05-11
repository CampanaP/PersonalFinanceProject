using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionType
{
    [WolverineHandler]
    public class TransactionTypeUpdateByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeUpdateByIdHandler(IEntityMapperService entityMapperService, ITransactionTypeService transactionTypeService)
        {
            _entityMapperService = entityMapperService;
            _transactionTypeService = transactionTypeService;
        }

        public async Task Handle(TransactionTypeUpdateByIdRequest request, CancellationToken cancellationToken = default)
        {
            Entities.TransactionType transactionType = _entityMapperService.Map<TransactionTypeUpdateByIdRequest, Entities.TransactionType>(request, true);

            await _transactionTypeService.UpdateById(transactionType, cancellationToken);

            return;
        }
    }
}