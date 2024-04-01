using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transactions.DbContexts;
using PersonalFinanceProject.Business.Transactions.Entities;
using PersonalFinanceProject.Business.Transactions.Interfaces.Repositories;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Attributes;

namespace PersonalFinanceProject.Business.Transactions.Repositories
{
    [ScopedLifetime]
    internal class TransactionCategoryRepository : ITransactionCategoryRepository
    {
        public readonly TransactionDbContext _transactionDbContext;

        public TransactionCategoryRepository(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }

        public async Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _transactionDbContext.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default)
        {
            return await _transactionDbContext.TransactionCategories.ToListAsync(cancellationToken);
        }
    }
}