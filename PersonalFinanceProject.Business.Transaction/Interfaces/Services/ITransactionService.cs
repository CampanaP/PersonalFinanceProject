namespace PersonalFinanceProject.Business.Transaction.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<Guid> Add(Entities.Transaction transaction, CancellationToken cancellationToken = default);
        Task DeleteById(Guid id, CancellationToken cancellationToken = default);
        Task<Entities.Transaction?> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Entities.Transaction>> GetList(CancellationToken cancellationToken = default);
        Task Update(Entities.Transaction transaction, CancellationToken cancellationToken = default);
    }
}