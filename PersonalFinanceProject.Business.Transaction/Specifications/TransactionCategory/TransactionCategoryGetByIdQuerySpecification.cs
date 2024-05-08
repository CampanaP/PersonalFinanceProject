using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Transaction.Specifications.TransactionCategory
{
    internal class TransactionCategoryGetByIdQuerySpecification : QuerySpecification<Entities.TransactionCategory>
    {
        public TransactionCategoryGetByIdQuerySpecification(int id) : base(tc => tc.Id == id)
        {
        }
    }
}