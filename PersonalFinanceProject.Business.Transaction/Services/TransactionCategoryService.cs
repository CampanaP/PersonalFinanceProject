using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Interfaces.Repositories;
using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Services
{
    [ScopedLifetime]
    public class TransactionCategoryService : ITransactionCategoryService
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;

        public TransactionCategoryService(ITransactionCategoryRepository transactionCategoryRepository)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
        }

        public async Task<int> Add(TransactionCategory transactionCategory, CancellationToken cancellationToken = default)
        {
            return await _transactionCategoryRepository.Add(transactionCategory, cancellationToken);
        }

        public async Task DeleteById(int id, CancellationToken cancellationToken = default)
        {
            await _transactionCategoryRepository.DeleteById(id, cancellationToken);

            return;
        }

        public async Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _transactionCategoryRepository.GetById(id, cancellationToken);
        }

        public async Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default)
        {
            return await _transactionCategoryRepository.GetList(cancellationToken);
        }

        public async Task Update(TransactionCategory transactionCategory, CancellationToken cancellationToken = default)
        {
            await _transactionCategoryRepository.Update(transactionCategory, cancellationToken);

            return;
        }
    }
}