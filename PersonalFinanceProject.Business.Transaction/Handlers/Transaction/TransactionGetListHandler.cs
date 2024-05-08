using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Communication.Message.Transaction.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.Transaction
{
    [WolverineHandler]
    public class TransactionGetListHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionService _transactionService;

        public TransactionGetListHandler(IEntityMapperService entityMapperService, ITransactionService transactionService)
        {
            _entityMapperService = entityMapperService;
            _transactionService = transactionService;
        }

        public async Task<TransactionGetListResponse> Handle(TransactionGetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionGetListResponse response = new TransactionGetListResponse();

            IEnumerable<Entities.Transaction> transactions = await _transactionService.GetList(cancellationToken);
            if (transactions is null || !transactions.Any())
            {
                return response;
            }

            response.Transactions = _entityMapperService.MapList<Entities.Transaction, TransactionResponseItem>(transactions.ToList(), true);

            return response;
        }
    }
}