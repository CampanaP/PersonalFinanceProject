using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Interfaces.Repositories;
using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Services
{
    [ScopedLifetime]
    internal class TransactionCategoryService : ITransactionCategoryService
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;

        public TransactionCategoryService(ITransactionCategoryRepository transactionCategoryRepository)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
        }

        public async Task<TransactionCategory?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _transactionCategoryRepository.GetById(id, cancellationToken);
        }

        public async Task<IEnumerable<TransactionCategory>> GetList(CancellationToken cancellationToken = default)
        {
            return await _transactionCategoryRepository.GetList(cancellationToken);
        }
    }
}