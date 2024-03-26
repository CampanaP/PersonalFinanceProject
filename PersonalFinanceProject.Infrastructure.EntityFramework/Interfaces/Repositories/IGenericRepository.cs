using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Repositories
{
    public interface IGenericRepository<TDbContext, TEntity>
    {
        Task Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken = default);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task SaveChanges(CancellationToken cancellationToken = default);

        IEnumerable<TEntity> Search(ISpecification<TEntity> specification);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}