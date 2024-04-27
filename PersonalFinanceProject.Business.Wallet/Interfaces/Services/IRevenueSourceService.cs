using PersonalFinanceProject.Business.Wallet.Entities;

namespace PersonalFinanceProject.Business.Wallet.Interfaces.Services
{
    public interface IRevenueSourceService
    {
        Task<Guid> Add(RevenueSource revenueSource, CancellationToken cancellationToken = default);

        Task DeleteById(Guid id, CancellationToken cancellationToken = default);

        Task<RevenueSource?> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<RevenueSource>> GetList(CancellationToken cancellationToken = default);

        Task Update(RevenueSource revenueSource, CancellationToken cancellationToken = default);
    }
}