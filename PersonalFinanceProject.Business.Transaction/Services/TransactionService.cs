using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Interfaces.Services;
using PersonalFinanceProject.Business.Transaction.Specifications.TransactionType;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;

namespace PersonalFinanceProject.Business.Transaction.Services
{
    [ScopedLifetime]
    public class TransactionService
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
            await _genericRepository.Delete(new TransactionTypeGetByIdQuerySpecification(id), cancellationToken);

            return;
        }

        public async Task<TransactionType?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _genericRepository.GetItem(new TransactionTypeGetByIdQuerySpecification(id), cancellationToken);
        }

        public async Task<IEnumerable<TransactionType>> GetList(CancellationToken cancellationToken = default)
        {
            return await _genericRepository.GetItems(cancellationToken);
        }

        public async Task Update(TransactionType transactionType, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Update(
                new TransactionTypeGetByIdQuerySpecification(transactionType.Id),
                new TransactionTypeUpdateSpecification(transactionType.Name),
                cancellationToken);

            return;
        }
    }
}