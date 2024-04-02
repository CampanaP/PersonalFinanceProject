using PersonalFinanceProject.Business.Transaction.Entities;

namespace PersonalFinanceProject.Business.Transaction.Interfaces.Repositories
{
    public interface ITransactionCategoryRepository
    {
        Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default);
    }
}