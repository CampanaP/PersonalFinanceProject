using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.ExtensionMethods;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Library.EntityFramework.Repositories
{
    [ScopedLifetime]
    public class GenericRepository<TDbContext, TEntity> : IGenericRepository<TDbContext, TEntity> where TDbContext : DbContext where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public GenericRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public virtual async Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual IEnumerable<TEntity> Search(ISpecification<TEntity> specification)
        {
            return _dbContext.Set<TEntity>().Search(specification);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}