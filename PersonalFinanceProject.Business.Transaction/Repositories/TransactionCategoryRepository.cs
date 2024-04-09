using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Interfaces.Repositories;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;

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

        public async Task<int> Add(TransactionCategory transactionCategory, CancellationToken cancellationToken = default)
        {
            await _transactionDbContext.TransactionCategories.AddAsync(transactionCategory, cancellationToken);
            await _transactionDbContext.SaveChangesAsync();

            return transactionCategory.Id;
        }

        public async Task DeleteById(int id, CancellationToken cancellationToken = default)
        {
            await _transactionDbContext.TransactionCategories.Where(tc => tc.Id == id).ExecuteDeleteAsync(cancellationToken);

            return;
        }

        public async Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _transactionDbContext.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default)
        {
            return await _transactionDbContext.TransactionCategories.ToListAsync(cancellationToken);
        }

        public async Task Update(TransactionCategory transactionCategory, CancellationToken cancellationToken = default)
        {
            await _transactionDbContext.TransactionCategories
                .Where(tc => tc.Id == transactionCategory.Id)
                .ExecuteUpdateAsync(tc => tc.SetProperty(i => i.Name, transactionCategory.Name), cancellationToken);

            await _transactionDbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}