using PersonalFinanceProject.Business.Wallet.DbContexts;
using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Business.Wallet.Specifications;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;

namespace PersonalFinanceProject.Business.Wallet.Services
{
    [ScopedLifetime]
    public class RevenueSourceService : IRevenueSourceService
    {
        private readonly IGenericRepository<RevenueSource, WalletDbContext> _genericRepository;

        public RevenueSourceService(IGenericRepository<RevenueSource, WalletDbContext> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Guid> Add(RevenueSource revenueSource, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Add(revenueSource, cancellationToken);
            await _genericRepository.SaveChanges(cancellationToken);

            return revenueSource.Id;
        }

        public async Task DeleteById(Guid id, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Delete(new RevenueSourceGetByIdQuerySpecification(id), cancellationToken);
            await _genericRepository.SaveChanges(cancellationToken);

            return;
        }

        public async Task<RevenueSource?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            RevenueSource? revenueSource = await _genericRepository.GetItem(new RevenueSourceGetByIdQuerySpecification(id), cancellationToken);

            return revenueSource;
        }

        public async Task<IEnumerable<RevenueSource>> GetList(CancellationToken cancellationToken = default)
        {
            IEnumerable<RevenueSource> revenueSources = await _genericRepository.GetItems(cancellationToken);

            return revenueSources;
        }

        public async Task Update(RevenueSource revenueSource, CancellationToken cancellationToken = default)
        {
            await _genericRepository.Update(
                new RevenueSourceGetByIdQuerySpecification(revenueSource.Id),
                new RevenueSourceUpdateSpecification(revenueSource.Name, revenueSource.UserId, revenueSource.CreateDate, revenueSource.UpdateDate),
                cancellationToken);
        }
    }
}