using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TDbContext> where TEntity : class where TDbContext : DbContext
    {
        Task Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Delete(TEntity entity);

        Task Delete(QuerySpecification<TEntity> specification, CancellationToken cancellationToken);

        void DeleteRange(IEnumerable<TEntity> entities);

        Task<TEntity?> GetItem(CancellationToken cancellationToken = default);

        Task<TEntity?> GetItem(QuerySpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(QuerySpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task SaveChanges(CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        Task Update(QuerySpecification<TEntity> querySpecification, UpdateSpecification<TEntity> updateSpecification, CancellationToken cancellationToken = default);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}