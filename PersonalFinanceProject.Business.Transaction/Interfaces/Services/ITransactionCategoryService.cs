using PersonalFinanceProject.Business.Transactions.Entities;

namespace PersonalFinanceProject.Business.Transactions.Interfaces.Services
{
    public interface ITransactionCategoryService
    {
        Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default);
    }
}