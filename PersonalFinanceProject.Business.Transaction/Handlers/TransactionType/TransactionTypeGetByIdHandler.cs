using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Communication.Message.TransactionType.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionType
{
    [WolverineHandler]
    public class TransactionTypeGetByIdHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeGetByIdHandler(IEntityMapperService entityMapperService, ITransactionTypeService transactionTypeService)
        {
            _entityMapperService = entityMapperService;
            _transactionTypeService = transactionTypeService;
        }

        public async Task<TransactionTypeGetByIdResponse> Handle(TransactionTypeGetByIdRequest request, CancellationToken cancellationToken = default)
        {
            TransactionTypeGetByIdResponse response = new TransactionTypeGetByIdResponse();

            Entities.TransactionType? transactionType = await _transactionTypeService.GetById(request.Id, cancellationToken);
            if (transactionType is null)
            {
                return response;
            }

            response.TransactionType = _entityMapperService.Map<Entities.TransactionType, TransactionTypeResponseItem>(transactionType, true);

            return response;
        }
    }
}