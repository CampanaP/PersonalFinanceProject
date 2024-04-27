using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityFramework.DbContexts;
using PersonalFinanceProject.Library.EntityFramework.ExtensionMethods;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Library.EntityFramework.Repositories
{
    [ScopedLifetime]
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly GenericDbContext _dbContext;

        public GenericRepository(GenericDbContext dbContext)
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

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}