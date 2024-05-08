using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Communication.Message.TransactionType.Responses;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Handlers.TransactionType
{
    [WolverineHandler]
    public class TransactionTypeGetListHandler
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeGetListHandler(IEntityMapperService entityMapperService, ITransactionTypeService transactionTypeService)
        {
            _entityMapperService = entityMapperService;
            _transactionTypeService = transactionTypeService;
        }

        public async Task<TransactionTypeGetListResponse> Handle(TransactionTypeGetListRequest request, CancellationToken cancellationToken = default)
        {
            TransactionTypeGetListResponse response = new TransactionTypeGetListResponse();

            IEnumerable<Entities.TransactionType> transactionTypes = await _transactionTypeService.GetList(cancellationToken);
            if (transactionTypes is null || !transactionTypes.Any())
            {
                return response;
            }

            response.TransactionTypes = _entityMapperService.MapList<Entities.TransactionType, TransactionTypeResponseItem>(transactionTypes.ToList(), true);

            return response;
        }
    }
}