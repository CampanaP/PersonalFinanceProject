using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Specifications.TransactionCategory;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;

namespace PersonalFinanceProject.Business.Transaction.Services
{
    [ScopedLifetime]
    public class TransactionCategoryService : ITransactionCategoryService
    {
        private readonly IGenericRepository<TransactionCategory, TransactionDbContext> _genericRepository;

        public TransactionCategoryService(IGenericRepository<TransactionCategory, TransactionDbContext> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<int> Add(TransactionCategory transactionCategory, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Add(transactionCategory, cancellationToken);
            await _genericRepository.SaveChanges(cancellationToken);

            return transactionCategory.Id;
        }

        public async Task DeleteById(int id, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Delete(new TransactionCategoryGetByIdQuerySpecification(id), cancellationToken);

            return;
        }

        public async Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _genericRepository.GetItem(new TransactionCategoryGetByIdQuerySpecification(id), cancellationToken);
        }

        public async Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default)
        {
            return await _genericRepository.GetItems(cancellationToken);
        }

        public async Task Update(TransactionCategory transactionCategory, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Update(
                new TransactionCategoryGetByIdQuerySpecification(transactionCategory.Id),
                new TransactionCategoryUpdateSpecification(transactionCategory.Name),
                cancellationToken);

            return;
        }
    }
}