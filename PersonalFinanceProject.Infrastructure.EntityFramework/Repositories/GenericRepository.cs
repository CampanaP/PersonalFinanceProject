using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Attributes;
using PersonalFinanceProject.Infrastructure.EntityFramework.ExtensionMethods;
using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.Repositories
{
    [ScopedLifetime]
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GenericDbContext _dbContext;

        public GenericRepository(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        }

        public virtual async Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetItems(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public virtual async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual IEnumerable<T> Search(ISpecification<T> specification)
        {
            return _dbContext.Set<T>().Search(specification);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }
    }
}