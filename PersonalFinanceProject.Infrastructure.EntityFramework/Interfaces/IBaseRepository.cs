namespace PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetItems();

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);
    }
}