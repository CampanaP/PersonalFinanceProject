using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Specifications.Transaction;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;

namespace PersonalFinanceProject.Business.Transaction.Services
{
    [ScopedLifetime]
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Entities.Transaction, TransactionDbContext> _genericRepository;

        public TransactionService(IGenericRepository<Entities.Transaction, TransactionDbContext> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Guid> Add(Entities.Transaction transaction, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Add(transaction, cancellationToken);
            await _genericRepository.SaveChanges(cancellationToken);

            return transaction.Id;
        }

        public async Task DeleteById(Guid id, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Delete(new TransactionGetByIdQuerySpecification(id), cancellationToken);

            return;
        }

        public async Task<Entities.Transaction?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _genericRepository.GetItem(new TransactionGetByIdQuerySpecification(id), cancellationToken);
        }

        public async Task<IEnumerable<Entities.Transaction>> GetList(CancellationToken cancellationToken = default)
        {
            return await _genericRepository.GetItems(cancellationToken);
        }

        public async Task Update(Entities.Transaction transaction, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Update(
                new TransactionGetByIdQuerySpecification(transaction.Id),
                new TransactionUpdateSpecification(transaction.Name, transaction.Amount, transaction.CategoryId, transaction.TypeId, transaction.SourceId, transaction.CreateDate, transaction.UpdateDate),
                cancellationToken);

            return;
        }
    }
}