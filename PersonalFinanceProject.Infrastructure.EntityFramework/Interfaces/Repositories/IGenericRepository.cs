using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task Add(T entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetItems(CancellationToken cancellationToken = default);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task SaveChanges(CancellationToken cancellationToken = default);

        IEnumerable<T> Search(ISpecification<T> specification);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);
    }
}