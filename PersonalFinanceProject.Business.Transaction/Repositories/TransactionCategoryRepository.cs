using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Interfaces.Repositories;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Repositories
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