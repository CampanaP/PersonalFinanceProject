using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Transaction.Specifications.TransactionCategory
{
    internal class TransactionCategoryUpdateSpecification : UpdateSpecification<Entities.TransactionCategory>
    {
        public TransactionCategoryUpdateSpecification(string name) : base(u => u.SetProperty(tc => tc.Name, name))
        {
        }
    }
}