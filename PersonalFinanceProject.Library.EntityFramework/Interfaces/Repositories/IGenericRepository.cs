using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TDbContext> where TEntity : class where TDbContext : DbContext
    {
        Task Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity?> GetItem(CancellationToken cancellationToken = default);

        Task<TEntity?> GetItem(GenericSpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(GenericSpecification<TEntity> specification, CancellationToken cancellationToken = default);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task SaveChanges(CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}