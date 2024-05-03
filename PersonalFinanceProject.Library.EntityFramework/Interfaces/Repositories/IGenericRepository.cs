using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PersonalFinanceProject.Library.EntityFramework.Specifications;
using System.Linq.Expressions;

namespace PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TDbContext> where TEntity : class where TDbContext : DbContext
    {
        Task Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Delete(TEntity entity);

        Task Delete(GenericSpecification<TEntity> specification, CancellationToken cancellationToken);

        void DeleteRange(IEnumerable<TEntity> entities);

        Task<TEntity?> GetItem(CancellationToken cancellationToken = default);

        Task<TEntity?> GetItem(GenericSpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetItems(GenericSpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task SaveChanges(CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        Task Update(GenericSpecification<TEntity> specification, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> properties, CancellationToken cancellationToken = default);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}