using PersonalFinanceProject.Business.Transaction.Entities;

namespace PersonalFinanceProject.Business.Transaction.Interfaces.Services
{
    public interface ITransactionTypeService
    {
        Task<int> Add(TransactionType transactionType, CancellationToken cancellationToken = default);
        Task DeleteById(int id, CancellationToken cancellationToken = default);
        Task<TransactionType?> GetById(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TransactionType>> GetList(CancellationToken cancellationToken = default);
        Task Update(TransactionType transactionType, CancellationToken cancellationToken = default);
    }
}