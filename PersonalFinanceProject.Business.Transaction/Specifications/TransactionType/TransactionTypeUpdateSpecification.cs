using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Transaction.Specifications.TransactionType
{
    internal class TransactionTypeUpdateSpecification : UpdateSpecification<Entities.TransactionType>
    {
        public TransactionTypeUpdateSpecification(string name) : base(u => u.SetProperty(tt => tt.Name, name))
        {
        }
    }
}