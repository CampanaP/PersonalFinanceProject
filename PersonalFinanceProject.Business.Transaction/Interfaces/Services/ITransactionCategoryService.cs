using PersonalFinanceProject.Business.Transaction.Entities;

namespace PersonalFinanceProject.Business.Transaction.Interfaces.Services
{
    public interface ITransactionCategoryService
    {
        Task<int> Add(TransactionCategory transactionCategory, CancellationToken cancellationToken = default);

        Task DeleteById(int id, CancellationToken cancellationToken = default);

        Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default);
    }
}