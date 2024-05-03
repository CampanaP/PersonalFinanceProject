using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.ExtensionMethods;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Specifications;
using System.Linq.Expressions;

namespace PersonalFinanceProject.Library.EntityFramework.Repositories
{
    [ScopedLifetime]
    public class GenericRepository<TEntity, TDbContext> : IGenericRepository<TEntity, TDbContext> where TEntity : class where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;

        public GenericRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<TEntity> search(GenericSpecification<TEntity> specification)
        {
            return _dbContext.Set<TEntity>().Search(specification);
        }

        public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task Delete(GenericSpecification<TEntity> specification, CancellationToken cancellationToken)
        {
            await search(specification).ExecuteDeleteAsync(cancellationToken);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity?> GetItem(CancellationToken cancellationToken = default)
        {
            TEntity? item = null;

            item = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(cancellationToken);

            return item;
        }

        public async Task<TEntity?> GetItem(GenericSpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            TEntity? item = null;

            item = await search(specification).FirstOrDefaultAsync(cancellationToken);

            return item;
        }

        public async Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> items = Enumerable.Empty<TEntity>();

            items = await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);

            return items;
        }

        public async Task<IEnumerable<TEntity>> GetItems(GenericSpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> items = Enumerable.Empty<TEntity>();

            items = await search(specification).ToListAsync(cancellationToken);

            return items;
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task Update(GenericSpecification<TEntity> specification, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> properties, CancellationToken cancellationToken = default)
        {
            await search(specification).ExecuteUpdateAsync(properties, cancellationToken);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}