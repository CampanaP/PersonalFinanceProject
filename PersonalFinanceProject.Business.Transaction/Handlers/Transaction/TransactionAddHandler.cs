using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Communication.Message.Transaction.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.Transaction
{
    [WolverineHandler]
    public class TransactionAddHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionService _transactionService;

        public TransactionAddHandler(IEntityMapperService entityMapperService, ITransactionService transactionService)
        {
            _entityMapperService = entityMapperService;
            _transactionService = transactionService;
        }

        public async Task<TransactionAddResponse> Handle(TransactionAddRequest request, CancellationToken cancellationToken = default)
        {
            TransactionAddResponse response = new TransactionAddResponse(Guid.Empty);

            Entities.Transaction transaction = _entityMapperService.Map<TransactionAddRequest, Entities.Transaction>(request, true);

            response.Id = await _transactionService.Add(transaction, cancellationToken);

            return response;
        }
    }
}