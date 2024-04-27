using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Business.Wallet.Specifications;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;

namespace PersonalFinanceProject.Business.Wallet.Services
{
    internal class RevenueSourceService : IRevenueSourceService
    {
        private readonly IGenericRepository<RevenueSource> _genericRepository;

        public RevenueSourceService(IGenericRepository<RevenueSource> genericRepository)
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
            //_specification.Where(x => x.)

            //RevenueSource revenueSource = await _genericRepository.Search()
            return;
        }

        public async Task<RevenueSource?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            RevenueSource? revenueSource = await _genericRepository.GetItem(new RevenueSourceGetByIdSpecification(id), cancellationToken);

            return revenueSource;
        }

        public async Task<IEnumerable<RevenueSource>> GetList(CancellationToken cancellationToken = default)
        {
            IEnumerable<RevenueSource> revenueSources = await _genericRepository.GetItems(cancellationToken);

            return revenueSources;
        }

        public async Task Update(RevenueSource revenueSource, CancellationToken cancellationToken)
        {
            return;
        }
    }
}