using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Infrastructure.EntityFramework.ExtensionMethods;
using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CustomDbContext _dbContext;

        public GenericRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<T>> GetItems()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public virtual async Task AddRange(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
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