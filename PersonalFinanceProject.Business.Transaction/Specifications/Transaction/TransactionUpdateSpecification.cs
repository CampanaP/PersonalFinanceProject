using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Transaction.Specifications.Transaction
{
    internal class TransactionUpdateSpecification : UpdateSpecification<Entities.Transaction>
    {
        public TransactionUpdateSpecification(string name, double amount, int categoryId, int typeId, Guid sourceId, DateTime createDate, DateTime updateDate)
            : base(u =>
                u.SetProperty(t => t.Name, name)
                .SetProperty(t => t.Amount, amount)
                .SetProperty(t => t.CategoryId, categoryId)
                .SetProperty(t => t.TypeId, typeId)
                .SetProperty(t => t.SourceId, sourceId)
                .SetProperty(t => t.CreateDate, createDate)
                .SetProperty(t => t.UpdateDate, updateDate))
        {
        }
    }
}