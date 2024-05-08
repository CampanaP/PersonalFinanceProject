using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Transaction.Specifications.Transaction
{
    internal class TransactionGetByIdQuerySpecification : QuerySpecification<Entities.Transaction>
    {
        public TransactionGetByIdQuerySpecification(Guid id) : base(t => t.Id == id)
        {
        }
    }
}