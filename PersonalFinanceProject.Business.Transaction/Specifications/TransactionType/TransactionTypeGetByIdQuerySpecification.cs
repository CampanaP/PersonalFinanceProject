using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Transaction.Specifications.TransactionType
{
    internal class TransactionTypeGetByIdQuerySpecification : QuerySpecification<Entities.TransactionType>
    {
        public TransactionTypeGetByIdQuerySpecification(int id) : base(tt => tt.Id == id)
        {
        }
    }
}