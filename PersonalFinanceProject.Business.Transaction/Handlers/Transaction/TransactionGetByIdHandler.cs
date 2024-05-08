using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Communication.Message.Transaction.Responses;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Communication.Message.TransactionType.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.Transaction
{
    [WolverineHandler]
    public class TransactionGetByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionService _transactionService;

        public TransactionGetByIdHandler(IEntityMapperService entityMapperService, ITransactionService transactionService)
        {
            _entityMapperService = entityMapperService;
            _transactionService = transactionService;
        }

        public async Task<TransactionGetByIdResponse> Handle(TransactionGetByIdRequest request, CancellationToken cancellationToken = default)
        {
            TransactionGetByIdResponse response = new TransactionGetByIdResponse();

            Entities.Transaction? transaction = await _transactionService.GetById(request.Id, cancellationToken);
            if (transaction is null)
            {
                return response;
            }

            response.Transaction = _entityMapperService.Map<Entities.Transaction, TransactionResponseItem>(transaction, true);

            return response;
        }
    }
}